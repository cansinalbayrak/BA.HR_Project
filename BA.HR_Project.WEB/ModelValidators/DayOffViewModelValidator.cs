using BA.HR_Project.Domain.Enums;
using BA.HR_Project.WEB.Models;
using Castle.Core.Internal;
using FluentValidation;

namespace BA.HR_Project.WEB.ModelValidators
{
    public class DayOffViewModelValidator : AbstractValidator<DayOffViewModel>
    {
        public DayOffViewModelValidator()
        {
            RuleFor(x => x.StartDate)
                .NotNull()
                .WithMessage("Start date cannot be empty.")
                .GreaterThan(x => DateTime.Now)  // Opsiyonel: StartDate'nin şu andan önce bir tarih olmasını sağlamak için.
                .WithMessage("Start date must be in the future.")
                .Must(BeInCurrentYear)
                .WithMessage("Start date must be in the current year.");

            RuleFor(x => x.FinishDate)
                .GreaterThan(x => x.StartDate)
                .WithMessage("Finish date must be greater than start date.")
                .When(x => x.StartDate != null);  // FinishDate sadece StartDate dolu olduğunda kontrol edilsin.
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description field is required")
                .MaximumLength(80).WithMessage("Description cannot be more than 80 characters");
        }

        private bool BeInCurrentYear(DateTime startDate)
        {
            return startDate.Year == DateTime.Now.Year;
        }

    }
}



