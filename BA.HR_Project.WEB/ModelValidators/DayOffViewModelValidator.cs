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
               if (dayOffType == DayOffType.AnnualDayOff)
               {
                   var workTime = (DateTime.Now - model.AppUser.StartDate.Value).TotalDays;

                   if (workTime < 365)
                   {
                       model.ErrorMsg = "Annual leave request not eligible.";
                       return false;
                   }
                   else if (workTime >= 365 && workTime < 6 * 365)
                   {
                       var maxAllowedFinishDate = model.StartDate.AddDays(14 - model.DayCount ?? 0);
                       if (model.FinishDate > maxAllowedFinishDate)
                       {
                           model.ErrorMsg = $"Finish date cannot exceed {maxAllowedFinishDate:yyyy-MM-dd}.";
                           return false;
                       }
                   }
                   else if (workTime >= 6 * 365)
                   {
                       var maxAllowedFinishDate = model.StartDate.AddDays(20 - model.DayCount ?? 0);
                       if (model.FinishDate > maxAllowedFinishDate)
                       {
                           model.ErrorMsg = $"Finish date cannot exceed {maxAllowedFinishDate:yyyy-MM-dd}.";
                           return false;
                       }
                   }

                   return true; // Geçerli olduğunu belirtmek için true döndürün.
               }

               return true; // MaternityDayOff değilse valid olarak kabul edin.
           })
           .WithMessage(x => x.ErrorMsg);

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

             if (dayOffType == DayOffType.PregnancyCheckupDayOff)
             {
                 if (model.Gender != Gender.Female)
                 {
                     model.ErrorMsg = "Gender must be Female for Pregnancy Checkup Day Off.";
                     return false;
                 }

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

            if (dayOffType == DayOffType.BreastfeedingDayOff)
            {
                if (model.Gender != Gender.Female)
                {
                    model.ErrorMsg = "Gender must be Female for Pregnancy Checkup Day Off.";
                    return false;
                }

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

        private int ValidateDayOffType(DayOffViewModel model)
        {
            var workTime = (DateTime.Now - model.AppUser.StartDate.Value).TotalDays;

            if (workTime < 365)
            {
                return 1;
            }
            else if (workTime >= 365 && workTime < 6 * 365)
            {
                var maxAllowedFinishDate = model.StartDate.AddDays(14 - model.DayCount ?? 0);
                if (model.FinishDate > maxAllowedFinishDate)
                {
                    return 2;
                }
            }
            else if (workTime >= 6 * 365)
            {
                var maxAllowedFinishDate = model.StartDate.AddDays(20 - model.DayCount ?? 0);
                if (model.FinishDate > maxAllowedFinishDate)
                {
                    return 3;
                }
            }

            return 0; // Hata durumu olmadığında 0 döndürün.
        }
    }
}



//RuleFor(x => x)
//     .Custom((model, context) =>
//     {
//         if (model.AppUser != null && model.AppUser.StartDate.HasValue)
//         {
//             if (model.DayOffType == DayOffType.AnnualDayOff)
//             {
//                 var workTime = (DateTime.Now - model.AppUser.StartDate.Value).TotalDays;
//                 if (workTime < 365 && model.DayOffType == DayOffType.AnnualDayOff)
//                 {
//                     context.AddFailure("Annual leave request not eligible.");
//                 }
//                 else if (workTime >= 365 && workTime < 6 * 365 && model.DayOffType == DayOffType.AnnualDayOff)
//                 {
//                     var maxAllowedFinishDate = model.StartDate.AddDays(14 - model.DayCount ?? 0);
//                     if (model.FinishDate > maxAllowedFinishDate)
//                     {
//                         context.AddFailure($"Finish date cannot exceed {maxAllowedFinishDate:yyyy-MM-dd}.");
//                     }
//                 }
//                 else if (workTime >= 6 * 365 && model.DayOffType == DayOffType.AnnualDayOff)
//                 {
//                     var maxAllowedFinishDate = model.StartDate.AddDays(20 - model.DayCount ?? 0);
//                     if (model.FinishDate > maxAllowedFinishDate)
//                     {
//                         context.AddFailure($"Finish date cannot exceed {maxAllowedFinishDate:yyyy-MM-dd}.");
//                     }
//                 }
//             }


//             if (model.DayOffType == DayOffType.MaternityDayOff && model.Gender != Gender.Female)
//             {
//                 context.AddFailure("Gender must be Female for Maternity Day Off.");
//             }

//             if (model.DayOffType == DayOffType.PaternityDayOff && model.Gender != Gender.Male)
//             {
//                 context.AddFailure("Gender must be Male for Paternity Day Off.");
//             }

//             if (model.DayOffType == DayOffType.BereavementDayOff ||
//                 model.DayOffType == DayOffType.JobSearchDayOff ||
//                 model.DayOffType == DayOffType.MarriageDayOff)
//             {
//                 context.AddFailure("Finish date should not be specified for this day off type.");
//             }

//             // FinishDate boş olmalı
//             RuleFor(x => x.FinishDate)
//                 .Null()
//                 .WithMessage("Finish date should be empty.")
//                 .When(x => model.DayOffType != DayOffType.AnnualDayOff);  // AnnualDayOff dışındaki durumlar için kontrol et
//         }
//     });