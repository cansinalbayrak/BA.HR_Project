using BA.HR_Project.WEB.Models;
using FluentValidation;

namespace BA.HR_Project.WEB.ModelValidators
{
	public class DepartmentViewModelValidator: AbstractValidator<DepartmentViewModel>
	{
        public DepartmentViewModelValidator()
        {
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name must be provided");
		}
    }
}
