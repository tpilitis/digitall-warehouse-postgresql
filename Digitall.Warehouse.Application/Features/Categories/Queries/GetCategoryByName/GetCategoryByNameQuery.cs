using Digitall.Warehouse.Application.Abstractions.Messaging;
using Digitall.Warehouse.Application.Contracts.Responses;

namespace Digitall.Warehouse.Application.Features.Categories.Queries.GetCategoryByName;

public sealed record GetCategoryByNameQuery(string Name) : IQuery<GetCategoryByNameResponse>;
