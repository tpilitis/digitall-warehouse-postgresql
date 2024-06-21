using Digitall.Persistance.EF.Extensions;
using Digitall.Warehouse.Api.Extensions;
using Digitall.Warehouse.Api.Infrastructure.ExceptionHandling;
using Digitall.Warehouse.Application;
using Digitall.Warehouse.Application.Behaviors;
using Digitall.Warehouse.Application.Extensions;
using Digitall.Warehouse.Application.Features.Categories.Commands;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Events;

// seriLog 2lv initialisation
// require this so we can capture issues during the set up
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

// second level serilog initialisation
builder.Services.AddSerilog((serviceProvider, loggerConfiguration) =>
{
    loggerConfiguration
        .ReadFrom.Configuration(builder.Configuration)
        .ReadFrom.Services(serviceProvider)
        .Enrich.FromLogContext();
});

// Add services to the container.
builder.Services.AddPersistanceEF(builder.Configuration);

builder.Services.AddApplicationServices();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(ApplicationAssemblyReference.Assembly);

    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
    config.AddOpenBehavior(typeof(VoidCommandValidatiorBehavior<,>));
    config.AddOpenBehavior(typeof(UnitOfWorkBehavior<,>));
});

builder.Services.AddAutoMapper([ApplicationAssemblyReference.Assembly]);

builder.Services.AddValidatorsFromAssemblyContaining<CreateCategoryCommandValidator>();

var mvcBuilder = builder.Services.AddControllers();
mvcBuilder
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = actionContext =>
        {
            var modelState = actionContext.ModelState.Values;

            return new BadRequestObjectResult(modelState.ToErrorResponse());
        };
    });

builder.Services.AddStackExchangeRedisCache(opt => opt.Configuration = builder.Configuration.GetConnectionString("CacheConnection"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.SeedData().Run();
