using DDDT.Application.DataTransfer;
using DDDT.EfDataAccess;
using FluentValidation;
using System.Linq;

namespace DDDT.Implementation.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator(DDDTContext context)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(x => x.Username)
                .NotEmpty()
                .MinimumLength(4)
                .Must(x => !context.Users.Any(user => user.Username == x))
                .WithMessage("Username is already taken.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Must(x => !context.Users.Any(user => user.Email == x))
                .WithMessage("User with that email allready exist");
        }
    }
}
