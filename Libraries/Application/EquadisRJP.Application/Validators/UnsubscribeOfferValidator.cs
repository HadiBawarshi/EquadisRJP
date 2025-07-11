using EquadisRJP.Application.Commands;
using FluentValidation;

namespace EquadisRJP.Application.Validators
{
    public class UnsubscribeOfferValidator : AbstractValidator<UnsubscribeFromOfferCommand>
    {
        public UnsubscribeOfferValidator()
        {
            RuleFor(x => x.RetailerId).GreaterThan(0);
            RuleFor(x => x.OfferId).GreaterThan(0);
        }
    }
}
