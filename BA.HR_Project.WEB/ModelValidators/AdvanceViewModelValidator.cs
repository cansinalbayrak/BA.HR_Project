using BA.HR_Project.WEB.Models;
using FluentValidation;
using Newtonsoft.Json.Linq;

namespace BA.HR_Project.WEB.ModelValidators
{
    public class AdvanceViewModelValidator: AbstractValidator<AdvanceViewModel>
    {
        public AdvanceViewModelValidator()
        {
            RuleFor(x => x.Amount).NotEmpty().WithMessage("Amount field is required");
            RuleFor(x => x.Amount)
                .Must(BeAnInteger).WithMessage("Please enter number")
                .GreaterThanOrEqualTo(0).WithMessage("Amount cannot be negative");
            RuleFor(x => x.Description).MaximumLength(150).WithMessage("Description cannot be more than 150 characters");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description field is required")
                .MaximumLength(80).WithMessage("Description cannot be more than 80 characters");

        }
        private bool BeAnInteger(int? value)
        {
            return true;
        }

    }
}
