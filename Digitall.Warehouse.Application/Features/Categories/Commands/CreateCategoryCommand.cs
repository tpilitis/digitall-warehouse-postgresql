using Digitall.Warehouse.Application.Abstractions.Messaging;

namespace Digitall.Warehouse.Application.Features.Categories.Commands;

public sealed record CreateCategoryCommand(string Name) : ICommand;
