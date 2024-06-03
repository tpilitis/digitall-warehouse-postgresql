using Digitall.Warehouse.Application.Contracts.Shared;

namespace Digitall.Warehouse.Application.Contracts.Responses;

public record GetProductResponse(
    string Title,
    string Description,
    Money Price,
    string? Brand);
