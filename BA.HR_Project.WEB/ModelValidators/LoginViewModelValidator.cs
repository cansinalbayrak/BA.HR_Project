using BA.HR_Project.WEB.Models;
using FluentValidation;

namespace BA.HR_Project.WEB.ModelValidators
{
	public class LoginViewModelValidator: AbstractValidator<LoginUserViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Email)
           .NotEmpty().WithMessage("Email must be provided")
           .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.Password)
           .NotEmpty().WithMessage("Password must be provided");


        }

      

    }
}
