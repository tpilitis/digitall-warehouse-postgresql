using Digitall.Warehouse.Application.Abstractions.Messaging;
using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;
using Digitall.Warehouse.Domain.Shared;

namespace Digitall.Warehouse.Application.Features.Categories.Commands;

public class CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    : ICommandHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<Result> Handle(
        CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var category = Category.Create(request.Name);

        await _categoryRepository.AddAsync(category, cancellationToken);

        return Result.Success(category);
    }
}
