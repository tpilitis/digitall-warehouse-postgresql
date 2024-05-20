using Digital.Warehouse.Utils;
using Digitall.Warehouse.Application.Abstractions.Messaging;
using Digitall.Warehouse.Application.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Warehouse.Application.Categories.AddCategory;

public sealed record AddCategoryCommand(string Name) : ICommand;

/// CQRS with from scratch - https://www.youtube.com/watch?v=85YbMEb1qkQ
public sealed class AddCategoryCommandHandler(ICategoryRepository categoryRepository) : ICommandHandler<AddCategoryCommand>
{
    private readonly ICategoryRepository categoryRepository = categoryRepository;

    public async Task<Result> HandleAsync(AddCategoryCommand command, CancellationToken token)
    {
        // TODO: this needs to go into a service
        // first validate if category with such name does already exists
        var getCategory = await categoryRepository.GetByNameAsync(command.Name);
        if (getCategory != null)
        {
            return Result.Failure(
                new(
                    "Error.NotUnique",
                    $"A category with such name: '{command.Name}' already exists."));
        }

        var category = new Category()
        {
            Name = command.Name
        };

        await categoryRepository.AddAsync(category, token);

        return Result.Success();
    }
}
