using Digitall.Warehouse.Application.Abstractions.Messaging;
using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;
using Digitall.Warehouse.Domain.Shared;

namespace Digitall.Warehouse.Application.Products.Commands
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(
            CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            // TODO: Validator shall validate Brand does exsits;
            // TODO: Validate category does exists
            var brandTask = _unitOfWork.Brands.GetByIdAsync(request.BrandId, cancellationToken);
            var categoriesTask = _unitOfWork.Categories.GetAllByIdsAsync(request.categoryIds, cancellationToken);
            await Task.WhenAll(new List<Task>() { brandTask, categoriesTask });

            var brand = await brandTask;
            var categories = await categoriesTask;
            var product = Product.Create(
                request.Title,
                request.Description,
                request.Price,
                categories,
                brand);

            await _unitOfWork.Products.AddAsync(product, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
