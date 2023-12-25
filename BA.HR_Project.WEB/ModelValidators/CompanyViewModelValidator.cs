using BA.HR_Project.WEB.Models;
using FluentValidation;

namespace BA.HR_Project.WEB.ModelValidators
{
	public class CompanyViewModelValidator: AbstractValidator<CompanyViewModel>
	{
        public CompanyViewModelValidator()
        {
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name must be provided");
			RuleFor(x => x.LogoPath).NotEmpty().WithMessage("LogoPath must be provided");

			RuleFor(x => x.Name).MinimumLength(3).WithMessage("Name must be at least 3 characters long");
		}
    }
}
