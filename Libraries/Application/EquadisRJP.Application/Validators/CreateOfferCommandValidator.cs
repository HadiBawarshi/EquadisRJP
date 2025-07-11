using EquadisRJP.Application.Commands;
using FluentValidation;

namespace EquadisRJP.Application.Validators
{
    public class CreateOfferCommandValidator : AbstractValidator<CreateOfferCommand>
    {
        public CreateOfferCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
            RuleFor(x => x.ValidFrom).LessThan(x => x.ValidTo);
            RuleFor(x => x.DiscountValuePercentage).InclusiveBetween(1, 100);
        }
    }
}
