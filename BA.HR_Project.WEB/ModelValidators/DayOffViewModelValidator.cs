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
            RuleFor(x => x.FinishDate)
                .Must((model, finishDate) => ValidateFinishDate(model.DayOffType, model.Gender, finishDate))
                .WithMessage("Invalid finish date for the selected day off type and gender.");

            //RuleFor(x => x.StartDate)
            //    .Must((model, startDate) => ValidateStartDate(model.DayOffType, startDate))
            //    .WithMessage("Invalid start date for the selected day off type.");

            RuleFor(x => x.FinishDate)
                .Must((model, finishDate) => ValidateExcuseDayOffFinishDate(model.DayOffType, model.StartDate, finishDate))
                .WithMessage("Invalid finish date for Excuse Day Off. Finish date cannot be more than 2 days from the start date.");
            RuleFor(x => x.FinishDate)
            .Must((model, finishDate) => IsFinishDateValid(model.DayOffType, model.StartDate, finishDate))
            .WithMessage("Invalid finish date for the selected day off type.");

            //When(x => !string.IsNullOrEmpty(x.FinishDate), () =>
            //{
            //    RuleFor(x => x.FinishDate).Custom((finishDate, context) =>
            //    {
            //        if (context.ParentContext.InstanceToValidate.DayOffType == "PaternityDayOff")
            //        {
            //            context.AddFailure("Finish date should not be specified for Paternity Day Off.");
            //        }
            //        Diğer şartları buraya ekleyebilirsiniz
            //    });
            //});
        }
        private bool IsFinishDateValid(DayOffType dayOffType, DateTime startDate, DateTime? finishDate)
        {
            if (finishDate.HasValue)
            {
                // PaternityDayOff seçildiyse ve finishDate girildiyse hata ver
                if (dayOffType == DayOffType.PaternityDayOff)
                {
                    return false;
                }
            }

            return true;
        }
        private bool ValidateFinishDate(DayOffType dayOffType, Gender gender, DateTime? finishDate)
        {
            switch (dayOffType)
            {
                case DayOffType.MaternityDayOff:
                    return gender == Gender.Female && !finishDate.HasValue;
                case DayOffType.PaternityDayOff:
                    return gender == Gender.Male && !finishDate.HasValue;
                case DayOffType.BereavementDayOff:
                case DayOffType.JobSearchDayOff:
                case DayOffType.MarriageDayOff:
                case DayOffType.ExcuseDayOff:
                    return !finishDate.HasValue;
                default:
                    return true;
            }
        }

        //private bool ValidateStartDate(DayOffType dayOffType, DateTime startDate)
        //{
        //    switch (dayOffType)
        //    {
        //        case DayOffType.MaternityDayOff:
        //        case DayOffType.PaternityDayOff:
        //        case DayOffType.BereavementDayOff:
        //        case DayOffType.JobSearchDayOff:
        //        case DayOffType.MarriageDayOff:
        //        case DayOffType.ExcuseDayOff:
        //            return true; // No specific validation for start date
        //        default:
        //            return true;
        //    }
        //}

        private bool ValidateExcuseDayOffFinishDate(DayOffType dayOffType, DateTime startDate, DateTime? finishDate)
        {
            if (dayOffType == DayOffType.ExcuseDayOff && finishDate.HasValue)
            {
                var maxAllowedFinishDate = startDate.AddDays(2); // 2 days from the start date
                return finishDate.Value.Date <= maxAllowedFinishDate.Date;
            }
            return true;
        }
    }
}
