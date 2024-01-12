using BA.HR_Project.WEB.Models;
using FluentValidation;
using System.Linq;

namespace BA.HR_Project.WEB.ModelValidators
{
    public class ExpenseViewModelValidator : AbstractValidator<ExpenseViewModel>
    {
        public ExpenseViewModelValidator()
        {
            RuleFor(e=>e.RequestPrice).NotEmpty().WithMessage("Request price field is required")
                .GreaterThanOrEqualTo(0).WithMessage("Amount cannot be negative");

            RuleFor(x => x.File)
        .Must((model, file) =>
        {
            if (model.File != null)
            {
                var allowedExtensions = new[] { ".jpeg", ".jpg", ".png", ".pdf" };
                var fileExtension = Path.GetExtension(model.File.FileName).ToLowerInvariant();
                return allowedExtensions.Contains(fileExtension);
            }

            return false;
        })
        .WithMessage("File must be in .jpeg, .jpg,.png or .pdf format");
        }
    }
}
