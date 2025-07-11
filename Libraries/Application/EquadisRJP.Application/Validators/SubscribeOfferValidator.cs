using EquadisRJP.Application.Commands;
using FluentValidation;

namespace EquadisRJP.Application.Validators
{
    public class SubscribeOfferValidator : AbstractValidator<SubscribeToOfferCommand>
    {
        public SubscribeOfferValidator()
        {
            RuleFor(x => x.RetailerId).GreaterThan(0);
            RuleFor(x => x.OfferId).GreaterThan(0);
        }
    }
}
