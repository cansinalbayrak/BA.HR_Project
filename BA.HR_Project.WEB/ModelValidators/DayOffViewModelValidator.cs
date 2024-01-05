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
           .GreaterThan(x => x.StartDate)
           .WithMessage("Finish date must be greater than start date.");

            RuleFor(x => x)
                .Custom((model, context) =>
                {
                    if (model.AppUser != null && model.AppUser.StartDate.HasValue)
                    {
                        var workTime = (DateTime.Now - model.AppUser.StartDate.Value).TotalDays;
                        if (workTime < 365)
                        {
                            context.AddFailure("Annual leave request not eligible.");
                        }
                        else if (workTime >= 365 && workTime < 6 * 365)
                        {
                            // 1 ile 6 yıl arası
                            var maxAllowedFinishDate = model.StartDate.AddDays(14 - model.DayCount ?? 0);
                            if (model.FinishDate > maxAllowedFinishDate)
                            {
                                context.AddFailure($"Finish date cannot exceed {maxAllowedFinishDate:yyyy-MM-dd}.");
                            }
                        }
                        else if (workTime >= 6 * 365)
                        {
                            // 6 yıl ve sonrası
                            var maxAllowedFinishDate = model.StartDate.AddDays(20 - model.DayCount ?? 0);
                            if (model.FinishDate > maxAllowedFinishDate)
                            {
                                context.AddFailure($"Finish date cannot exceed {maxAllowedFinishDate:yyyy-MM-dd}.");
                            }
                        }
                    }

                    if (model.DayOffType == DayOffType.MaternityDayOff && model.Gender != Gender.Female)
                    {
                        context.AddFailure("Gender must be Female for Maternity Day Off.");
                    }

                    if (model.DayOffType == DayOffType.PaternityDayOff && model.Gender != Gender.Male)
                    {
                        context.AddFailure("Gender must be Male for Paternity Day Off.");
                    }

                    if (model.DayOffType == DayOffType.BereavementDayOff ||
                        model.DayOffType == DayOffType.JobSearchDayOff ||
                        model.DayOffType == DayOffType.MarriageDayOff)
                    {
                        context.AddFailure("Finish date should not be specified for this day off type.");
                    }
                });
        }
    }
}