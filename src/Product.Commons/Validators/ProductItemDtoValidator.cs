using FluentValidation;
using Product.Commons.Dtos;

namespace Product.Commons.Validators
{
    public class ProductItemDTOValidator : AbstractValidator<ProductItemDto>
    {
        public ProductItemDTOValidator()
        {
            RuleFor(pi => pi.Description)
                .NotEmpty()
                .WithMessage("Description is required.")
                .MaximumLength(255)
                .WithMessage("Description must have a maximum of 255 characters.");

            RuleFor(pi => pi.ManufacturingDate)
                .LessThanOrEqualTo(x => x.ExpirationDate)
                .When(pi => pi.ExpirationDate.HasValue)
                .WithMessage("Manufacturing date must not be greater than expiration date.");
        }
    }
}