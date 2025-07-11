using EquadisRJP.Application.Commands;
using FluentValidation;

namespace EquadisRJP.Application.Validators
{
    public class StartPartnershipCommandValidator : AbstractValidator<StartPartnershipCommand>
    {
        public StartPartnershipCommandValidator()
        {
            RuleFor(x => x.SupplierId).GreaterThan(0);
            RuleFor(x => x.RetailerId).GreaterThan(0);

            //RuleFor(x => x.ExpiryDate)
            //    .GreaterThan(x => x.StartDate)
            //    .When(x => x.ExpiryDate.HasValue);

            RuleFor(x => x.ExpiryDate)
            .Must(exp => !exp.HasValue || exp.Value > DateTime.UtcNow)
            .WithMessage("ExpiryDate must be in the future.");
        }
    }
}
