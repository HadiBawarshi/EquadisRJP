using EquadisRJP.Application.Commands;
using FluentValidation;

namespace EquadisRJP.Application.Validators
{
    public class CreateOfferCommandValidator : AbstractValidator<CreateOfferCommand>
    {
        public CreateOfferCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.").MaximumLength(100);
            RuleFor(x => x.ValidFrom).NotEmpty().WithMessage("ValidFrom is required.").LessThan(x => x.ValidTo).WithMessage("ValidFrom must be earlier than ValidTo.");
            RuleFor(x => x.DiscountValuePercentage).InclusiveBetween(1, 100).WithMessage("Discount must be between 1 and 100.");
            RuleFor(x => x.ValidTo)
            .NotEmpty().WithMessage("ValidTo is required.");
            RuleFor(x => x.SupplierId).GreaterThan(0).WithMessage("SupplierId must be greater than 0.");
        }
    }
}
