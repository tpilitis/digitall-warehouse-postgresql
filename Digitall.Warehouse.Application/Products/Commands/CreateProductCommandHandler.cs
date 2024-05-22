using Digitall.Warehouse.Application.Abstractions.Messaging;
using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;
using Digitall.Warehouse.Domain.Shared;

namespace Digitall.Warehouse.Application.Products.Commands
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        IProductRepository _productRepository;
        ICategoryRepository _categoryRepository;
        IBrandRepository _brandRepository;

        public CreateProductCommandHandler(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
        }

        public async Task<Result> Handle(
            CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            // TODO: Validator shall validate Brand does exsits;
            // TODO: Validate category does exists
            var brandTask = _brandRepository.GetByIdAsync(request.BrandId, cancellationToken);
            var categoriesTask = _categoryRepository.GetAllByIdsAsync(request.categoryIds, cancellationToken);
            await Task.WhenAll(new List<Task>() { brandTask, categoriesTask});

            var brand = await brandTask;
            var categories = await categoriesTask;
            var product = Product.Create(
                request.Title,
                request.Description,
                request.Price,
                categories, 
                brand);

            await _productRepository.AddAsync(product, cancellationToken);

            return Result.Success();
        }
    }
}
