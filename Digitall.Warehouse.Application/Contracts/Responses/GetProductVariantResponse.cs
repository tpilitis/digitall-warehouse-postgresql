using Digitall.Warehouse.Application.Contracts.Dtos;

namespace Digitall.Warehouse.Application.Contracts.Responses;

public sealed record GetProductVariantResponse(int ProductId, SizeDto Size, SwatchDto? Swatch, int Quantity);
