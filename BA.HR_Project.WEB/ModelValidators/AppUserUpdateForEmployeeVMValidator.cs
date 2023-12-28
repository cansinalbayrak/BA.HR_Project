using BA.HR_Project.WEB.Models;
using FluentValidation;

namespace BA.HR_Project.WEB.ModelValidators
{
    public class AppUserUpdateForEmployeeVMValidator : AbstractValidator<AppUserUpdateForEmployeeVM>
    {
        public AppUserUpdateForEmployeeVMValidator()
        {
   
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number must be provided")
                .Matches(@"^\d{10}$").WithMessage("Phone Number must contain 10 digits");

            RuleFor(x => x.Adress)
                .NotEmpty().WithMessage("Adress must be provided")
                .MaximumLength(80).WithMessage("Adress cannot be more than 80 characters");
            When(x => !x.UseExistingPhoto, () =>
            {
                RuleFor(x => x.Photo)
                    .NotEmpty().WithMessage("File must be provided or Choose This Photo");
            });
       

        }


    }
}
