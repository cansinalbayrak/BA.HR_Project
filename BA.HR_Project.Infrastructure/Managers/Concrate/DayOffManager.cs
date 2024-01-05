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
using Microsoft.EntityFrameworkCore;
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
        public async Task<Response> RequestDayOff(DayOffDto dayOffDto)
        {
            if (dayOffDto.DayOffType == DayOffType.AnnualDayOff)
            {
                return await RequestAnnualDayOff(dayOffDto);
            }
        
            else if (dayOffDto.DayOffType == DayOffType.MaternityDayOff)
            {
                return await RequestMaternityDayOff(dayOffDto);
            }
      
            else if (dayOffDto.DayOffType == DayOffType.PaternityDayOff)
            {
                return await RequestPaternityDayOff(dayOffDto);
            }
            else if (dayOffDto.DayOffType == DayOffType.BereavementDayOff)
            {
                return await RequestBereavementDayOff(dayOffDto);
            }
            else if (dayOffDto.DayOffType == DayOffType.JobSearchDayOff)
            {
                return await RequestJobSearchDayOff(dayOffDto);
            }
            else if (dayOffDto.DayOffType == DayOffType.MarriageDayOff)
            {
                return await RequestMarriageDayOff(dayOffDto);
            }
            else if (dayOffDto.DayOffType == DayOffType.ExcuseDayOff)
            {

            }
            else if (dayOffDto.DayOffType == DayOffType.AccompanyingDayOff)
            {
                return await RequestAccompanyingDayOff(dayOffDto);
            }
            else if (dayOffDto.DayOffType == DayOffType.SoldierLeave)
            {

            }


            return Response.Failure("Invalid day off type.");
        }
        private async Task<Response> RequestAccompanyingDayOff(DayOffDto dayOffDto)
        {
            var user = await _userManager.FindByIdAsync(dayOffDto.AppUserId);
            var DayOffs = await GetAll();
            if (user == null)
            {
                dayOffDto.DayCount += 0;
                return Response.Failure("User not found.");
            }
            dayOffDto.FinishDate = dayOffDto.StartDate.AddDays(90);
            dayOffDto.ConfirmStatus = ConfirmStatus.Waiting;
            dayOffDto.RequestDate = DateTime.Now;
            dayOffDto.Id = Guid.NewGuid().ToString();
            var result = await Insert(dayOffDto);

            return result.IsSuccess ? Response.Success() : Response.Failure("Failed to insert day off.");
        }
        private async Task<Response> RequestMarriageDayOff(DayOffDto dayOffDto)
        {
            var user = await _userManager.FindByIdAsync(dayOffDto.AppUserId);
            var DayOffs = await GetAll();
            if (user == null)
            {
                dayOffDto.DayCount += 0;
                return Response.Failure("User not found.");
            }
            dayOffDto.FinishDate = dayOffDto.StartDate.AddDays(7);
            dayOffDto.ConfirmStatus = ConfirmStatus.Waiting;
            dayOffDto.RequestDate = DateTime.Now;
            dayOffDto.Id = Guid.NewGuid().ToString();
            var result = await Insert(dayOffDto);

            return result.IsSuccess ? Response.Success() : Response.Failure("Failed to insert day off.");
        }
        private async Task<Response> RequestJobSearchDayOff(DayOffDto dayOffDto)
        {
            var user = await _userManager.FindByIdAsync(dayOffDto.AppUserId);
            var DayOffs = await GetAll();
            if (user == null)
            {
                return Response.Failure("User not found.");
            }
            dayOffDto.FinishDate = dayOffDto.StartDate.AddHours(2);
            dayOffDto.ConfirmStatus = ConfirmStatus.Waiting;
            dayOffDto.RequestDate = DateTime.Now;
            dayOffDto.Id = Guid.NewGuid().ToString();
            var result = await Insert(dayOffDto);

            return result.IsSuccess ? Response.Success() : Response.Failure("Failed to insert day off.");
        }
        private async Task<Response> RequestBereavementDayOff(DayOffDto dayOffDto)
        {
            var user = await _userManager.FindByIdAsync(dayOffDto.AppUserId);
            var DayOffs = await GetAll();
            if (user == null)
            {
                return Response.Failure("User not found.");
            }
            dayOffDto.FinishDate = dayOffDto.StartDate.AddDays(7);
            dayOffDto.ConfirmStatus = ConfirmStatus.Waiting;
            dayOffDto.RequestDate = DateTime.Now;
            dayOffDto.Id = Guid.NewGuid().ToString();
            var result = await Insert(dayOffDto);

            return result.IsSuccess ? Response.Success() : Response.Failure("Failed to insert day off.");
        }
        private async Task<Response> RequestMaternityDayOff(DayOffDto dayOffDto)
        {
            var user = await _userManager.FindByIdAsync(dayOffDto.AppUserId);
            var DayOffs = await GetAll();
            var annualDayOffs = DayOffs.Context.Where(d => d.DayOffType == DayOffType.AnnualDayOff &&
                                            d.StartDate.Year == DateTime.Now.Year && d.AppUserId == user.Id);
         

           
            if (user == null)
            {
                return Response.Failure("User not found.");
            }

            dayOffDto.FinishDate = dayOffDto.StartDate.AddDays(49);
            dayOffDto.ConfirmStatus = ConfirmStatus.Waiting;
            dayOffDto.RequestDate = DateTime.Now;
            dayOffDto.Id = Guid.NewGuid().ToString();
            var result = await Insert(dayOffDto);

            return result.IsSuccess ? Response.Success() : Response.Failure("Failed to insert day off.");
        }

        private async Task<Response> RequestPaternityDayOff(DayOffDto dayOffDto)
        {
            var user = await _userManager.FindByIdAsync(dayOffDto.AppUserId);
            var DayOffs = await GetAll();
            if (user == null)
            {
                return Response.Failure("User not found.");
            }
            dayOffDto.FinishDate = dayOffDto.StartDate.AddDays(49);
            dayOffDto.DayCount = 49;
            dayOffDto.ConfirmStatus = ConfirmStatus.Waiting;
            dayOffDto.RequestDate = DateTime.Now;
            dayOffDto.Id = Guid.NewGuid().ToString();
            var result = await Insert(dayOffDto);

            return result.IsSuccess ? Response.Success() : Response.Failure("Failed to insert day off.");
        }
        private async Task<Response> RequestAnnualDayOff( DayOffDto dayOffDto)
        {

            var user = await _userManager.FindByIdAsync(dayOffDto.AppUserId);
            var DayOffss = await GetAll();
            var annualDayOffs = DayOffss.Context.Where(d => d.DayOffType == DayOffType.AnnualDayOff &&
                                            d.StartDate.Year == DateTime.Now.Year&& d.AppUserId==user.Id);
      
            float annualDayOffTotalCount = annualDayOffs.Sum(d => d.DayCount);
            dayOffDto.DayCount = annualDayOffTotalCount;

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

                return Response.Failure("Annual leave request not eligible.");
            }
            // 1 ile 6 yıl arası ise (14 gün)
            else if (workTime.TotalDays >= 365 && workTime.TotalDays < 6 * 365)
            {



                if (dayOffDto.FinishDate > dayOffDto.StartDate.AddDays(14))
                {
                    return Response.Failure("cannot exceed 14 days.");
                }

                else if (dayOffDto.FinishDate <= dayOffDto.StartDate.AddDays(14) && dayOffDto.DayCount<=14)
                {
                    float dayDifference = (float)(dayOffDto.FinishDate - dayOffDto.StartDate).TotalDays;
                    dayOffDto.DayCount += dayDifference;
                    if (dayOffDto.FinishDate <= dayOffDto.StartDate.AddDays(14) && dayOffDto.DayCount <= 14)
                    {

                    }
                    else
                    {
                        return Response.Failure("cannot exceed 14 days.");
                    }

                }
                else
                    return Response.Failure("cannot exceed 14 days.");
            }
            // 6 yıl ve sonrasına 20 gün
            else
            {
                if (dayOffDto.FinishDate > dayOffDto.StartDate.AddDays(20))
                {
                    return Response.Failure("cannot exceed 20 days.");
                }
                else if (dayOffDto.FinishDate <= dayOffDto.StartDate.AddDays(20) && dayOffDto.DayCount <= 20)
                {
                    float dayDifference = (float)(dayOffDto.FinishDate - dayOffDto.StartDate).TotalDays;
                    dayOffDto.DayCount += dayDifference;
                    if (dayOffDto.FinishDate <= dayOffDto.StartDate.AddDays(20) && dayOffDto.DayCount <= 20)
                    {

                    }
                    else
                    {
                        return Response.Failure("cannot exceed 20 days.");
                    }

                }
                else
                    return Response.Failure("cannot exceed 20 days.");
            }
            dayOffDto.ConfirmStatus = ConfirmStatus.Waiting;
            dayOffDto.RequestDate = DateTime.Now;
            dayOffDto.Id = Guid.NewGuid().ToString();
           
            var result = await Insert(dayOffDto);
            //await _userManager.UpdateAsync(user);

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

