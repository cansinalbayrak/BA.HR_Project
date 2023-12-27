using BA.HR_Project.WEB.Models;
using FluentValidation;

namespace BA.HR_Project.WEB.ModelValidators
{
    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            RuleFor(x => x.Email)
           .NotEmpty().WithMessage("Email must be provided")
           .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.Password)
           .NotEmpty().WithMessage("Password must be provided")
           .MinimumLength(6).WithMessage("Password must be at least 6 characters")
           .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[.,#?'])[A-Za-z\d\.,#?']+$")
           .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character.");
            RuleFor(x => x.PasswordConfirm)
           .NotEmpty().WithMessage("Password confirmation must be provided")
           .Equal(x => x.Password).WithMessage("Password and confirmation must match");
        }
    }
}
