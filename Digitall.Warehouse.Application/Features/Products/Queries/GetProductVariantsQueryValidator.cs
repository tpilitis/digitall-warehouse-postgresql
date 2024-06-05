using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Application.Features.Products.Extensions;
using FluentValidation;

namespace Digitall.Warehouse.Application.Features.Products.Queries;

public class GetProductVariantsQueryValidator : AbstractValidator<GetProductVariantsQuery>
{
    public GetProductVariantsQueryValidator(IProductRepository productRepository)
    {
        RuleFor(command => command.ProductId)
            .ProductMustExist(productRepository);
    }
}
