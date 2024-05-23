using Digitall.Warehouse.Application.Abstractions.Messaging;
using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Warehouse.Application.Features.Products.Commands;

public sealed record CreateProductCommand(
    string Title,
    string Description,
    Guid BrandId,
    Price Price,
    List<Guid> CategoryIds)
    : ICommand;
