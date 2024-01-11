using BA.HR_Project.WEB.Models;
using FluentValidation;

namespace BA.HR_Project.WEB.ModelValidators
{
    public class AppUserUpdatePasswordViewModelValidator: AbstractValidator<AppUserUpdatePasswordViewModel>
    {
        public AppUserUpdatePasswordViewModelValidator()
        {
            RuleFor(x => x.OldPassword)
                    .NotEmpty().WithMessage("Old password is required.")
                    .Equal("Pw.1234").WithMessage("Wrong Old Pasword");

            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("New password is required.");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm password is required.")
                .Equal(x => x.NewPassword).WithMessage("Passwords do not match.");
        }
    }
}
