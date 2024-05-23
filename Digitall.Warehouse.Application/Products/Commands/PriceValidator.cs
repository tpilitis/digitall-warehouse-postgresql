using Digitall.Warehouse.Application.Constants;
using Digitall.Warehouse.Domain.Entities.Products;
using FluentValidation;

namespace Digitall.Warehouse.Application.Products.Commands;

public class PriceValidator : AbstractValidator<Price>
{
    public PriceValidator()
    {
        RuleFor(price => price.CurrencyCode)
            .NotEmpty()
            .MaximumLength(EntityTypeConstants.IsoCodeMaxLength);
        RuleFor(price => price.Value)
            .GreaterThan(0);
    }
}