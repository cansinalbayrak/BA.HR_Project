using FluentValidation;
using BA.HR_Project.WEB.Models;

namespace BA.HR_Project.WEB.ModelValidators
{
    public class UpdateUserProfileViewModelValidator:AbstractValidator<UpdateUserProfileViewModel>
    {
        public UpdateUserProfileViewModelValidator()
        {
            RuleFor(x => x.PhoneNumber)
               .NotEmpty().WithMessage("IdentityNumber must be provided")
               .Matches("^[0-9]{10}$").WithMessage("PhoneNumber must be a 11-digit numeric value");
        }
    }
}
