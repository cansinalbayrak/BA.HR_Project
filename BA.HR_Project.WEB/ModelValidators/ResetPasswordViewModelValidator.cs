using BA.HR_Project.WEB.Models;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace BA.HR_Project.WEB.ModelValidators
{
    public class ResetPasswordViewModelValidator : AbstractValidator<ResetPasswordViewModel>
    {
        public ResetPasswordViewModelValidator()
        {
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("New Password is required.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm Password is required.")
                .Equal(x => x.NewPassword).WithMessage("Passwords do not match.");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code is required.");
        }
    }
}
