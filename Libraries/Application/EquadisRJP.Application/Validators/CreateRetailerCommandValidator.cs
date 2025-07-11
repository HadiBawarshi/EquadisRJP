using EquadisRJP.Application.Commands;
using FluentValidation;

namespace EquadisRJP.Application.Validators
{
    public class CreateRetailerCommandValidator : AbstractValidator<CreateRetailerCommand>
    {


        public CreateRetailerCommandValidator()
        {
            RuleFor(o => o.Username)
               .NotEmpty()
               .WithMessage("{UserName} is required")
               .NotNull()
               .MaximumLength(70)
               .WithMessage("{UserName} must not exceed 70 characters");

            RuleFor(x => x.StoreName)
               .NotEmpty().
                WithMessage("{StoreName} is required");

            RuleFor(x => x.PhoneNumber)
               .NotEmpty()
               .WithMessage("{PhoneNumber} is required");

            RuleFor(x => x.Email)
              .NotEmpty()
              .WithMessage("Email is required")
              .EmailAddress()
              .WithMessage("Email format is invalid");


            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(8)
                .WithMessage("{Password} is required");


            RuleFor(x => x.StoreTypeId)
             .NotEmpty()
             .NotNull()
             .WithMessage("{StoreTypeId} is required");

            RuleFor(x => x.Location)
            .NotEmpty()
            .NotNull()
            .WithMessage("{Location} is required");

        }
    }
}
