using FluentValidation;

namespace Sample.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.ProductCode)
                .NotEmpty().WithMessage("{ProductCode} is required.")
                .NotNull()
                .MaximumLength(10).WithMessage("{ProductCode} must not exceed 50 characters.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{Description} is required.")
                .NotNull();

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{Price} is required.")
                .GreaterThan(0).WithMessage("{Price} should be greater than zero.");
        }
    }
}
