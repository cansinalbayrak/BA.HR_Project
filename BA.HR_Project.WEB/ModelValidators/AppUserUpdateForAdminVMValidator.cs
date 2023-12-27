using BA.HR_Project.WEB.Areas.Admin.Models;
using BA.HR_Project.WEB.Models;
using FluentValidation;

namespace BA.HR_Project.WEB.ModelValidators
{
    public class AppUserUpdateForAdminVMValidator : AbstractValidator<AppUserUpdateForAdminVM>
    {
        public AppUserUpdateForAdminVMValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name must be provided")
            .MaximumLength(30).WithMessage("Name cannot be more than 30 characters");

            RuleFor(x => x.SecondName)
                .MaximumLength(30).WithMessage("Second Name cannot be more than 30 characters");

            RuleFor(x => x.Email)
           .Must(BeValidEmail).WithMessage("Invalid email address format. It should end with @bilgeadamboost.com");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname must be provided")
                .MaximumLength(30).WithMessage("Surname cannot be more than 30 characters");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number must be provided")
                .Matches(@"^\d{10}$").WithMessage("Phone Number must contain 10 digits");

            RuleFor(x => x.BirthDate)
          .Must(BeAtLeast15YearsOld).WithMessage("Birth Date must be at least 15 years ago");

            RuleFor(x => x.Salary)
                .GreaterThanOrEqualTo(0).WithMessage("Salary cannot be negative");

            RuleFor(x => x.Adress)
                .NotEmpty().WithMessage("Adress must be provided")
                .MaximumLength(80).WithMessage("Adress cannot be more than 80 characters");

        }

        private bool BeAtLeast15YearsOld(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age))
            {
                age--;
            }

            return age >= 15;
        }
        private bool BeValidEmail(string email)
        {
            return email?.ToLowerInvariant().EndsWith("@bilgeadamboost.com") == true;
        }
    }
}
