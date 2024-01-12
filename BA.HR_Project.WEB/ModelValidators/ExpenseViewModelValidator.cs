using BA.HR_Project.WEB.Models;
using FluentValidation;

namespace BA.HR_Project.WEB.ModelValidators
{
    public class ExpenseViewModelValidator : AbstractValidator<ExpenseViewModel>
    {
        public ExpenseViewModelValidator()
        {
            RuleFor(e=>e.RequestPrice).NotEmpty().WithMessage("Request price field is required")
                .GreaterThanOrEqualTo(0).WithMessage("Amount cannot be negative");

        }
    }
}
