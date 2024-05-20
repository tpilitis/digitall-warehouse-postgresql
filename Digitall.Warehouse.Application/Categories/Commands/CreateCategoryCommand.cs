
using Digitall.Warehouse.Application.Abstractions.Messaging;

namespace Digitall.Warehouse.Application.Categories
{
    public sealed record CreateCategoryCommand(string Name) : ICommand;
}
