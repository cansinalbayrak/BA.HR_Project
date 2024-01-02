using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Application.Interfaces;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Domain.Enums;
using BA.HR_Project.Infrastructure.Services.Concrate;
using BA.HR_Project.Infrasturucture.Managers.Abstract;
using BA.HR_Project.Infrasturucture.RequestResponse;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Infrastructure.Managers.Concrate
{
    public class DayOffManager : BaseManager<DayOff, DayOffDto>, IDayOffService
    {

        public DayOffManager(IMapper mapper, IUow uow) : base(mapper, uow)
        {
           
        }
        public async Task<Response> RequestDayOff(string appUserId, DayOffDto dayOffDto)
        {
            if (dayOffDto.DayOffType == DayOffType.AnnualDayOff)
            {
                return await RequestAnnualDayOff(appUserId, dayOffDto);
            }
            else if (dayOffDto.DayOffType == DayOffType.WeeklyDayOff)
            {
                
            }
            else if (dayOffDto.DayOffType == DayOffType.MaternityDayOff)
            {

            }
            else if (dayOffDto.DayOffType == DayOffType.PregnancyCheckupDayOff)
            {

            }
            else if (dayOffDto.DayOffType == DayOffType.BreastfeedingDayOff)
            {

            }
            else if (dayOffDto.DayOffType == DayOffType.PaternityDayOff)
            {

            }
            else if (dayOffDto.DayOffType == DayOffType.BereavementDayOff)
            {

            }
            else if (dayOffDto.DayOffType == DayOffType.JobSearchDayOff)
            {

            }
            else if (dayOffDto.DayOffType == DayOffType.MaternityDayOff)
            {

            }
            else if (dayOffDto.DayOffType == DayOffType.ExcuseDayOff)
            {

            }
            else if (dayOffDto.DayOffType == DayOffType.AccompanyingDayOff)
            {

            }
            else if (dayOffDto.DayOffType == DayOffType.SoldierLeave)
            {

            }


            return Response.Failure("Invalid day off type.");
        }

        private async Task<Response> RequestAnnualDayOff(string appUserId,DayOffDto dayOffDto)
        {
            var appUser = await _uow.GetRepository<AppUser>().GetAsync(filter: u => u.Id == appUserId);
            var count = 0;

            if (appUser == null)
            {
                dayOffDto.DayCount += 0;
                return Response.Failure("User not found.");
                
            }

            var startWork = appUser.StartDate ?? DateTime.MinValue;
            var now = DateTime.Now;
            var workTime = now - startWork;


            // Bir yılı doldurmadıysa izin talep edemez
            if (workTime.TotalDays < 365)
            {
                // Bir yıl doldurmadı
                return Response.Failure("Annual leave request not eligible.");
            }

            // 1 ile 6 yıl arası ise (14 gün)
            else if (workTime.TotalDays >= 365 && workTime.TotalDays < 6 * 365)
            {
                dayOffDto.FinishDate = dayOffDto.StartDate.AddDays(14);
                dayOffDto.DayCount += 14;
            }

            // 6 yıl ve sonrasına 20 gün
            else
            {
                dayOffDto.FinishDate = dayOffDto.StartDate.AddDays(20);
                dayOffDto.DayCount += 14;
            }

            var result = await Insert(dayOffDto);

            return result;
        }

      
    }
}

