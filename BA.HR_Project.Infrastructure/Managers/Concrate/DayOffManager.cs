using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Application.Interfaces;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Domain.Enums;
using BA.HR_Project.Infrastructure.Services.Concrate;
using BA.HR_Project.Infrasturucture.Managers.Abstract;
using BA.HR_Project.Infrasturucture.RequestResponse;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Infrastructure.Managers.Concrate
{
    public class DayOffManager : BaseManager<DayOff, DayOffDto>, IDayOffService
    {
        private readonly UserManager<AppUser> _userManager;
        public DayOffManager(IMapper mapper, IUow uow, UserManager<AppUser> userManager = null) : base(mapper, uow)
        {
            _userManager = userManager;
        }
        public async Task<Response> RequestDayOff( DayOffDto dayOffDto)
        {
            if (dayOffDto.DayOffType == DayOffType.AnnualDayOff)
            {
                return await RequestAnnualDayOff(dayOffDto);
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

        private async Task<Response> RequestAnnualDayOff( DayOffDto dayOffDto)
        {

            var user = await _userManager.FindByIdAsync(dayOffDto.AppUserId);
            var DayOffs = await GetAll();
            //var individualDayOff = DayOffs.Context.Where(x => x.AppUserId == dayOffDto.AppUserId && x.DayOffType == DayOffType.ExcuseDayOff && (x.ConfirmStatus == ConfirmStatus.Waiting || x.ConfirmStatus == ConfirmStatus.Approved));
            //var institutionalDayOffs = DayOffs.Context.Where(x => x.AppUserId == dayOffDto.AppUserId && x.DayOffType == DayOffType.AnnualDayOff && (x.ConfirmStatus == ConfirmStatus.Waiting || x.ConfirmStatus == ConfirmStatus.Approved));

            if (user == null)
            {
                dayOffDto.DayCount += 0;
                return Response.Failure("User not found.");
            }

            var startWork = user.StartDate ?? DateTime.MinValue;
            var now = DateTime.Now;
            var workTime = now - startWork;

            // Bir yılı doldurmadıysa izin talep edemez
            if (workTime.TotalDays < 365)
            {
                // Bir yıl doldurmadı
                // return Response.Failure("Annual leave request not eligible.");
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
                dayOffDto.DayCount += 20;
            }
            dayOffDto.ConfirmStatus = ConfirmStatus.Waiting;
            dayOffDto.RequestDate = DateTime.Now;
            dayOffDto.Id = Guid.NewGuid().ToString();
            var result = await Insert(dayOffDto);

            return result.IsSuccess ? Response.Success() : Response.Failure("Failed to insert day off.");
        }


        public async Task<List<DayOffDto>> GetAllDayOff(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var DayOff = await GetAll();
            var userDayOff = DayOff.Context.Where(x => x.AppUserId == userId).OrderBy(x => x.RequestDate).ToList();
            return userDayOff;
        }


    }
}

