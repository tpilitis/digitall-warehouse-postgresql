using Digitall.Warehouse.Application.Abstractions.Messaging;
using Digitall.Warehouse.Application.Contracts.Responses;

namespace Digitall.Warehouse.Application.Features.Products.Queries;

public record class GetProductsQuery(string Title, int Skip = 0, int Take = 50)
    : IQuery<List<GetProductResponse>>;
