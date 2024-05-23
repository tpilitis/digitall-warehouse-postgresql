using Digitall.Warehouse.Application.Abstractions.Messaging;

namespace Digitall.Warehouse.Application.Features.Categories.Queries.GetCategoryByName;

public sealed record GetCategoryByNameQuery(string Name) : IQuery<GetCategoryByNameResponse>;
