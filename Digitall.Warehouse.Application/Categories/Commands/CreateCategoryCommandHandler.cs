using Digitall.Warehouse.Application.Abstractions.Messaging;
using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;
using Digitall.Warehouse.Domain.Shared;

namespace Digitall.Warehouse.Application.Categories.Commands
{
    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(
            CreateCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var category = Category.Create(request.Name);

            await _unitOfWork.Categories.AddAsync(category, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success(category);
        }
    }
}
