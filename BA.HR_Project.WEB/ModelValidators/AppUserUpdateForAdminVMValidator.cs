using BA.HR_Project.WEB.Areas.Admin.Models;
using BA.HR_Project.WEB.Models;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BA.HR_Project.WEB.ModelValidators
{
    public class AppUserUpdateForAdminVMValidator : AbstractValidator<AppUserUpdateForAdminVM>
    {
        public AppUserUpdateForAdminVMValidator()
        {
            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("Name must be provided")
                 .Must(name => !string.IsNullOrWhiteSpace(name) && !ContainsTurkishCharacter(name))
                 .WithMessage("Name cannot be empty and cannot contain Turkish characters")
                 .MaximumLength(30).WithMessage("Name cannot be more than 30 characters");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname must be provided")
                .Must(surname => !string.IsNullOrWhiteSpace(surname) && !ContainsTurkishCharacter(surname))
                .WithMessage("Surname cannot be empty and cannot contain Turkish characters")
                .MaximumLength(30).WithMessage("Name cannot be more than 30 characters");

            RuleFor(x => x.SecondName)
              .Must(SecondName => string.IsNullOrWhiteSpace(SecondName) || !ContainsTurkishCharacter(SecondName))
              .WithMessage("Surname can be empty, but if provided, it must contain Turkish characters")
              .MaximumLength(30).WithMessage("SecondName cannot be more than 30 characters");

            RuleFor(x => x.SecondSurname)
                .Must(SecondSurname => string.IsNullOrWhiteSpace(SecondSurname) || !ContainsTurkishCharacter(SecondSurname))
                .WithMessage("Surname can be empty, but if provided, it must contain Turkish characters")
                .MaximumLength(30).WithMessage("SecondSurname cannot be more than 30 characters");
            //       RuleFor(x => x.Email)
            //.NotEmpty().WithMessage("Email must be provided")
            //.Must(BeValidEmail).WithMessage("Invalid email address format. It should end with @bilgeadamboost.com");

            RuleFor(x => x.IsTurkishCitizen)
                   .Must((model, isTurkishCitizen) => !isTurkishCitizen || IsValidTurkishIdentityNumberOrTcNo(model.IdentityNumber, isTurkishCitizen))
                   .WithMessage("Invalid Turkish Identity Number or T.C. should be true");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number must be provided")
                .Matches(@"^\d{10}$").WithMessage("Phone Number must contain 10 digits");

            RuleFor(x => x.BirthDate).NotNull().WithMessage("BirthDate must be provided")
          .Must(BeAtLeast15YearsOld).WithMessage("Birth Date must be at least 15 years ago");

            RuleFor(x => x.Salary)
                .GreaterThanOrEqualTo(0).WithMessage("Salary cannot be negative");

            RuleFor(x => x.Adress)
                .NotEmpty().WithMessage("Adress must be provided")
                .MaximumLength(80).WithMessage("Adress cannot be more than 80 characters");
            RuleFor(x => x.Salary).NotEmpty().WithMessage("Salary must be provided");
            RuleFor(x => x.BirthPlace)
               .NotEmpty().WithMessage("BirthPlace must be provided");
            //RuleFor(x => x.EndDate)
            //   .Must((model, endDate) => endDate == null || endDate > model.StartDate)
            //   .WithMessage("EndDate must be null or greater than StartDate");
            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date must be provided");

        }
        private bool IsValidTurkishIdentityNumberOrTcNo(string identityNumber, bool isTurkishCitizen)
        {
            if (!isTurkishCitizen)
            {
                return true;
            }

            return IsValidKimlikNo(identityNumber);
        }

        private bool IsValidKimlikNo(string kimlikNo)
        {
            if (kimlikNo == null)
            {
                return false;
            }
            if (kimlikNo.Length != 11 || !Regex.IsMatch(kimlikNo, @"^\d+$") || kimlikNo[0] == '0')
            {
                return false;
            }

            int[] digits = kimlikNo.Select(c => Convert.ToInt32(c.ToString())).ToArray();

            int oddSum = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
            int evenSum = digits[1] + digits[3] + digits[5] + digits[7];

            int total = (oddSum * 7 - evenSum) % 10;

            if (digits[9] != total)
            {
                return false;
            }

            int total2 = (oddSum + evenSum + digits[9]) % 10;

            return digits[10] == total2;
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

        private bool ContainsTurkishCharacter(string text)
        {
            return text.Any(char.IsLetter) && text.Any(ch => "İÖÜĞŞÇçüöış ".Contains(ch));
        }
    }
}
