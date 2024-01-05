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
        .WithMessage("Start date must be in the future.");

            RuleFor(x => x.FinishDate)
                .GreaterThan(x => x.StartDate)
                .WithMessage("Finish date must be greater than start date.")
                .When(x => x.StartDate != null);  // FinishDate sadece StartDate dolu olduğunda kontrol edilsin.

            RuleFor(x => x.StartDate.Year)
                .Equal(DateTime.Now.Year)
                .WithMessage("Start date must be in the current year.")
                .When(x => x.StartDate != null);

            RuleFor(x => x.FinishDate.Value.Year)
                .Equal(DateTime.Now.Year)
                .WithMessage("Finish date must be in the current year.")
                .When(x => x.FinishDate != null);

            RuleFor(x => x.DayOffType)
            .Must((model, dayOffType) =>
            {

                if (dayOffType == DayOffType.MaternityDayOff)
                {
                    // MaternityDayOff özel kontrolleri
                    if (model.Gender != Gender.Female)
                    {
                        model.ErrorMsg = "Gender must be Female for Maternity Day Off.";
                        return false;
                    }

                    if (model.FinishDate.HasValue)
                    {
                        model.ErrorMsg = "Finish date should be empty for Maternity Day Off.";
                        return false;
                    }

                    return true; // Geçerli olduğunu belirtmek için true döndürün.
                }

                return true; // MaternityDayOff değilse valid olarak kabul edin.
            })
            .WithMessage(x => x.ErrorMsg);

            RuleFor(x => x.DayOffType)
           .Must((model, dayOffType) =>
           {

               if (dayOffType == DayOffType.JobSearchDayOff)
               {


                   if (model.FinishDate.HasValue)
                   {
                       model.ErrorMsg = "Finish date should be empty for Job Search DayOff.";
                       return false;
                   }

                   return true; // Geçerli olduğunu belirtmek için true döndürün.
               }

               return true; // MaternityDayOff değilse valid olarak kabul edin.
           })
           .WithMessage(x => x.ErrorMsg);

            RuleFor(x => x.DayOffType)
          .Must((model, dayOffType) =>
          {

              if (dayOffType == DayOffType.MarriageDayOff)
              {


                  if (model.FinishDate.HasValue)
                  {
                      model.ErrorMsg = "Finish date should be empty for Marriage DayOff.";
                      return false;
                  }

                  return true; // Geçerli olduğunu belirtmek için true döndürün.
              }

              return true; // MaternityDayOff değilse valid olarak kabul edin.
          })
          .WithMessage(x => x.ErrorMsg);

            RuleFor(x => x.DayOffType)
          .Must((model, dayOffType) =>
          {

              if (dayOffType == DayOffType.PaternityDayOff)
              {
                  if (model.Gender != Gender.Male)
                  {
                      model.ErrorMsg = "Gender must be Female for Paternity Day Off.";
                      return false;
                  }

                  if (model.FinishDate.HasValue)
                  {
                      model.ErrorMsg = "Finish date should be empty Paternity DayOff.";
                      return false;
                  }

                  return true; // Geçerli olduğunu belirtmek için true döndürün.
              }

              return true; // MaternityDayOff değilse valid olarak kabul edin.
          })
          .WithMessage(x => x.ErrorMsg);

            RuleFor(x => x.DayOffType)
        .Must((model, dayOffType) =>
        {

            if (dayOffType == DayOffType.BereavementDayOff)
            {

                if (model.FinishDate.HasValue)
                {
                    model.ErrorMsg = "Finish date should be empty Pregnancy Checkup DayOff.";
                    return false;
                }

                return true; // Geçerli olduğunu belirtmek için true döndürün.
            }

            return true; // MaternityDayOff değilse valid olarak kabul edin.
        })
        .WithMessage(x => x.ErrorMsg);

            RuleFor(x => x.DayOffType)
        .Must((model, dayOffType) =>
        {

            if (dayOffType == DayOffType.ExcuseDayOff)
            {

                if (model.FinishDate.HasValue)
                {
                    model.ErrorMsg = "Finish date should be empty Pregnancy Checkup DayOff.";
                    return false;
                }

                return true; // Geçerli olduğunu belirtmek için true döndürün.
            }

            return true; // MaternityDayOff değilse valid olarak kabul edin.
        })
        .WithMessage(x => x.ErrorMsg);

            RuleFor(x => x.DayOffType)
        .Must((model, dayOffType) =>
        {

            if (dayOffType == DayOffType.AccompanyingDayOff)
            {
                if (model.Gender != Gender.Female)
                {
                    model.ErrorMsg = "Gender must be Female for Pregnancy Checkup Day Off.";
                    return false;
                }
                return true; // Geçerli olduğunu belirtmek için true döndürün.
            }

            return true; // MaternityDayOff değilse valid olarak kabul edin.
        })
        .WithMessage(x => x.ErrorMsg);
        }

    }
}



