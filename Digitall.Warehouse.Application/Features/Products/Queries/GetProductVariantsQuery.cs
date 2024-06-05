using Digitall.Warehouse.Application.Abstractions.Messaging;
using Digitall.Warehouse.Application.Contracts.Responses;

namespace Digitall.Warehouse.Application.Features.Products.Queries
{
    public record GetProductVariantsQuery(Guid ProductId): IQuery<List<GetProductVariantResponse>>;
}
