using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Application.Features.Categories;
using FluentValidation;
using MediatR;

namespace Digitall.Warehouse.Application.Features.Products.Extensions
{
    public static class FluentValidatorExtensions
    {
        public static IRuleBuilder<TRequest, Guid> ProductMustExist<TRequest>(
            this IRuleBuilder<TRequest, Guid> ruleBuilder,
            IProductRepository productRepository)
            where TRequest : IBaseRequest
        {
           return ruleBuilder
                .NotEmpty()
                .MustAsync(async (pId, cancellationToken) =>
                {
                    var product = await productRepository.GetByIdAsync(pId, cancellationToken);
                    return product != null;
                })
                .WithErrorCode(ValidationFailureCodes.ProductNotFound.Name)
                .WithMessage(ValidationFailureCodes.ProductNotFound.Value);
        }
    }
}
