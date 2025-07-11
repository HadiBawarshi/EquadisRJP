using EquadisRJP.Application.Commands;
using FluentValidation;

namespace EquadisRJP.Application.Validators
{
    public class UpdateOfferCommandValidator : AbstractValidator<UpdateOfferCommand>
    {
        public UpdateOfferCommandValidator()
        {
            RuleFor(x => x.ValidFrom).LessThan(x => x.ValidTo);
            RuleFor(x => x.DiscountValuePercentage).InclusiveBetween(1, 100)
                .When(x => !x.Archive);
        }
    }
}
