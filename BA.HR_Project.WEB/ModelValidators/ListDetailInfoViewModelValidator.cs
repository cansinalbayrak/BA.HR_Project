using FluentValidation;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.WEB.Models;

namespace BA.HR_Project.WEB.ModelValidators
{
    public class ListDetailInfoViewModelValidator: AbstractValidator<ListDetailInfoViewModel>
    {
        public ListDetailInfoViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must be provided");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname must be provided");
            RuleFor(x => x.PhotoPath).NotEmpty().WithMessage("PhotoPath must be provided");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("BirthDate must be provided");
            RuleFor(x => x.BirthPlace).NotEmpty().WithMessage("BirthPlace must be provided");
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("StartDate must be provided");

            // IdentityNumber için özel kural
            RuleFor(x => x.IdentityNumber)
                .NotEmpty().WithMessage("IdentityNumber must be provided")
                .Matches("^[0-9]{11}$").WithMessage("IdentityNumber must be a 11-digit numeric value");

        }
    }
}
