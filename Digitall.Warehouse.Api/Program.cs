using Digitall.Persistance.EF.Extensions;
using Digitall.Warehouse.Api.Extensions;
using Digitall.Warehouse.Application;
using Digitall.Warehouse.Application.Behaviors;
using Digitall.Warehouse.Application.Categories.Commands;
using FluentValidation;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistanceEF(builder.Configuration);
 
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(AssemblyReference.Assembly);

    // this below does not register the behavior ...
    // config.AddBehavior(typeof(RequestValidatiorBehavior<,>));
});

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidatiorBehavior<,>));

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(VoidCommandValidatiorBehavior<,>));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.SeedData().Run();
