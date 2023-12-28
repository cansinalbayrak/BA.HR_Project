using BA.HR_Project.WEB.Models;
using FluentValidation;

namespace BA.HR_Project.WEB.ModelValidators
{
	public class AppUserViewModelValidator: AbstractValidator<AppUserViewModel>
	{

        public AppUserViewModelValidator()
        {
            RuleFor(x => x.Name)
       .NotEmpty().WithMessage("Name must be provided")
       .Must(name => !string.IsNullOrWhiteSpace(name) && !ContainsTurkishCharacter(name))
       .WithMessage("Name cannot be empty and cannot contain Turkish characters");
            RuleFor(x => x.Surname)
        .NotEmpty().WithMessage("Surname must be provided")
        .Must(surname => !string.IsNullOrWhiteSpace(surname) && !ContainsTurkishCharacter(surname))
        .WithMessage("Surname cannot be empty and cannot contain Turkish characters");
            RuleFor(x => x.PhotoPath).NotEmpty().WithMessage("PhotoPath must be provided");
			RuleFor(x => x.BirthDate).NotEmpty().WithMessage("BirthDate must be provided");
            RuleFor(x => x.BirthPlace).NotEmpty().WithMessage("BirthPlace must be provided");
			RuleFor(x => x.StartDate).NotEmpty().WithMessage("StartDate must be provided");
			RuleFor(x => x.IdentityNumber)
				.NotEmpty().WithMessage("IdentityNumber must be provided")
				.Matches("^[0-9]{11}$").WithMessage("IdentityNumber must be a 11-digit numeric value");
		}

        private bool ContainsTurkishCharacter(string text)
        {
       
            return text.Any(char.IsLetter) && text.Any(ch => "çğıiİıöşüÇĞİIÖŞÜ".Contains(ch));
        }
      
    }
}
