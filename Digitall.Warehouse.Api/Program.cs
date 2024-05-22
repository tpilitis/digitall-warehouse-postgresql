using Digitall.Persistance.EF.Extensions;
using Digitall.Warehouse.Api.Extensions;
using Digitall.Warehouse.Api.Infrastructure.ExceptionHandling;
using Digitall.Warehouse.Application;
using Digitall.Warehouse.Application.Behaviors;
using Digitall.Warehouse.Application.Categories.Commands;
using FluentValidation;
using MediatR;
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
 
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(AssemblyReference.Assembly);

    config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
    config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(VoidCommandValidatiorBehavior<,>));
    config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(RequestValidatiorBehavior<,>));
});

builder.Services.AddValidatorsFromAssemblyContaining<CreateCategoryCommandValidator>();

builder.Services.AddControllers();

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
