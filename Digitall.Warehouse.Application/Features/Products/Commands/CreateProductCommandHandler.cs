using Digitall.Warehouse.Application.Abstractions.Messaging;
using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;
using Digitall.Warehouse.Domain.Shared;

namespace Digitall.Warehouse.Application.Features.Products.Commands;

public class CreateProductCommandHandler(
    ICategoryRepository categoryRepository,
    IProductRepository productRepository) : ICommandHandler<CreateProductCommand>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<Result> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

        var product = Product.Create(
            request.Title,
            request.Description,
            request.Price,
            request.BrandId,
            category!);

        await _productRepository.AddAsync(product, cancellationToken);

        return Result.Success();
    }
}
