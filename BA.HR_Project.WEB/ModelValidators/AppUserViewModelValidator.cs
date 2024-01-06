using BA.HR_Project.WEB.Models;
using FluentValidation;

namespace BA.HR_Project.WEB.ModelValidators
{
    public class AppUserViewModelValidator : AbstractValidator<AppUserViewModel>
    {

        public AppUserViewModelValidator()
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

            RuleFor(x => x.PhotoPath)
                .NotEmpty().WithMessage("PhotoPath must be provided");

            RuleFor(x => x.BirthDate)
                .NotNull().WithMessage("BirthDate must be provided")
                .Must(BeAtLeast15YearsOld).WithMessage("The user must be at least 15 years old");

            RuleFor(x => x.BirthPlace)
                .NotEmpty().WithMessage("BirthPlace must be provided");

            //RuleFor(x => x.StartDate)
            //    .NotEmpty().WithMessage("StartDate must be provided");

            RuleFor(x => x.EndDate)
                .Must((model, endDate) => endDate == null || endDate > model.StartDate)
                .WithMessage("EndDate must be null or greater than StartDate");

    //        RuleFor(x => x.IsTurkishCitizen)
    //.Must((model, isTurkishCitizen) => !isTurkishCitizen || IsValidTurkishIdentityNumberOrTcNo(model.IdentityNumber, isTurkishCitizen))
    //.WithMessage("Invalid Turkish Identity Number or T.C. should be true");

            RuleFor(x => x.PhoneNumber)
    .NotEmpty().WithMessage("PhoneNumber must be provided")
    .Matches("^[0-9]{10}$").WithMessage("PhoneNumber must be a 10-digit numeric value");

            RuleFor(x => x.Salary)
    .NotNull().WithMessage("Salary must be provided")
    .NotEmpty().WithMessage("Salary must be provided");

            RuleFor(x => x.Salary)
              .GreaterThanOrEqualTo(0).WithMessage("Salary cannot be negative");

            RuleFor(x => x.Adress)
                .NotEmpty().WithMessage("Adress must be provided")
                .MaximumLength(80).WithMessage("Adress cannot be more than 80 characters");



        }

        private bool BeValidPassportNo(string passportNumber)
        {
            return !string.IsNullOrEmpty(passportNumber) && passportNumber.Length == 9;
        }

        private bool IsValidTurkishIdentityNumberOrTcNo(string identityNumber, bool isTurkishCitizen)
        {
            if (!isTurkishCitizen)
            {
                return true;
            }

            if (string.IsNullOrEmpty(identityNumber) || identityNumber.Length != 11)
            {
                return false;
            }

            int[] digits = identityNumber.Select(c => int.Parse(c.ToString())).ToArray();
            int sum = digits.Take(10).Sum();
            int tenthDigit = sum % 10;

            if (tenthDigit != digits[9])
            {
                return false;
            }

            int eleventhDigit = (sum + digits[10]) % 10;
            return eleventhDigit == digits[10];
        }

        private bool ContainsTurkishCharacter(string text)
        {
            return text.Any(char.IsLetter) && text.Any(ch => "İÖÜĞŞÇçüöış ".Contains(ch));
        }

        private bool BeAtLeast15YearsOld(DateTime? birthDate)
        {
            if (birthDate == null)
            {
                return false;
            }

            var today = DateTime.Today;
            var age = today.Year - birthDate.Value.Year;

            return age >= 15;
        }


    }
}
