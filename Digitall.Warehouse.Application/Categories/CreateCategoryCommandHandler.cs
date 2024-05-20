using Digitall.Warehouse.Application.Abstractions.Messaging;
using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;
using Digitall.Warehouse.Domain.Shared;

namespace Digitall.Warehouse.Application.Categories
{
    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(
            CreateCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var existingCategory = await _categoryRepository.GetByNameAsync(request.Name);
            if (existingCategory != null)
            {
                // category must be unique
                return Result.Failure(Error.DuplicatedValue(nameof(request.Name)));
            }

            var category = new Category()
            {
                Name = request.Name,
            };

            await _categoryRepository.AddAsync(category, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success(category);
        }
    }
}
