using EquadisRJP.Application.Commands;
using FluentValidation;

namespace EquadisRJP.Application.Validators
{
    public class RenewPartnershipCommandValidator : AbstractValidator<RenewPartnershipCommand>
    {
        public RenewPartnershipCommandValidator()
        {
            RuleFor(x => x.NewExpiryDate)
                .Must(d => d > DateTime.UtcNow)
                .WithMessage("New expiry date must be in the future.");
        }
    }
}
