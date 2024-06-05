using Digitall.Warehouse.Application.Abstractions.Messaging;

namespace Digitall.Warehouse.Application.Features.Products.Commands
{
    public record AddProductVariantCommand(Guid ProductId, Guid SizeId, int Quantity, Guid? SwatchId) : ICommand;
}
