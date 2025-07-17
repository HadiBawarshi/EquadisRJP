using EquadisRJP.Application.Commands;
using FluentValidation;

namespace EquadisRJP.Application.Validators
{
    public class UpdateOfferCommandValidator : AbstractValidator<UpdateOfferCommand>
    {
        public UpdateOfferCommandValidator()
        {
            RuleFor(x => x.ValidFrom).LessThan(x => x.ValidTo);
            //RuleFor(x => x.DiscountValuePercentage).InclusiveBetween(1, 100)
            //    .When(x => !x.Archive);
            //RuleFor(x => x.SupplierId).GreaterThan(0).WithMessage("SupplierId must be greater than 0.");

            When(x => !x.Archive, () =>
            {
                // If client sends a Title, validate its length; otherwise ignore
                RuleFor(x => x.Title)
                    .MaximumLength(100).When(x => x.Title is not null);

                RuleFor(x => x.ValidFrom)
                    .NotEmpty().WithMessage("ValidFrom is required when updating an offer.")  // optional if you allow partial updates
                    .LessThan(x => x.ValidTo)
                    .WithMessage("ValidFrom must be earlier than ValidTo.");

                RuleFor(x => x.ValidTo)
                    .NotEmpty().WithMessage("ValidTo is required when updating an offer.");

                RuleFor(x => x.DiscountValuePercentage)
                    .InclusiveBetween(1, 100)
                    .WithMessage("Discount must be between 1 and 100.");
            });

            // No additional rules needed when Archive == true
        }

    }
}

