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
                await Reset(dayOffDto);
                return await RequestAnnualDayOff(dayOffDto);
            }
        
            else if (dayOffDto.DayOffType == DayOffType.MaternityDayOff)
            {
                await Reset(dayOffDto);
                return await RequestMaternityDayOff(dayOffDto);
            }
      
            else if (dayOffDto.DayOffType == DayOffType.PaternityDayOff)
            {
                await Reset(dayOffDto);
                return await RequestPaternityDayOff(dayOffDto);
            }
            else if (dayOffDto.DayOffType == DayOffType.BereavementDayOff)
            {
                await Reset(dayOffDto);
                return await RequestBereavementDayOff(dayOffDto);
            }
            else if (dayOffDto.DayOffType == DayOffType.JobSearchDayOff)
            {
                await Reset(dayOffDto);
                return await RequestJobSearchDayOff(dayOffDto);
            }
            else if (dayOffDto.DayOffType == DayOffType.MarriageDayOff)
            {
                await Reset(dayOffDto);
                return await RequestMarriageDayOff(dayOffDto);
            }
            else if (dayOffDto.DayOffType == DayOffType.ExcuseDayOff)
            {
                await Reset(dayOffDto);
                return await RequestExcuseDayOff(dayOffDto);
            }
            else if (dayOffDto.DayOffType == DayOffType.SickDayOff)
            {
                await Reset(dayOffDto);
                return await RequestSickDayOff(dayOffDto);
            }
            else if (dayOffDto.DayOffType == DayOffType.SoldierLeave)
            {
                await Reset(dayOffDto);
                return await RequestSoldierLeave(dayOffDto);
            }


            return Response.Failure("Invalid day off type.");
        }
        private async Task<Response> Reset(DayOffDto dayOffDto)
        {
            var user = await _userManager.FindByIdAsync(dayOffDto.AppUserId);
            var dayOffs = await GetAll();
            var userDayOffs = dayOffs.Context.Where(d => d.AppUserId == user.Id).ToList();
            var lastUserDayOff = userDayOffs.OrderByDescending(d => d.Id).FirstOrDefault();
            if (lastUserDayOff != null && lastUserDayOff.StartDate.Year!=DateTime.Now.Year)
            {
                await Delete(dayOffDto);
            }
            return Response.Success();
        }
        private async Task<Response> IsEligibleForNewDayOff(DayOffDto dayOffDto)
        {
            var user = await _userManager.FindByIdAsync(dayOffDto.AppUserId);
            var dayOffs = await GetAll();

            var userDayOffs = dayOffs.Context.Where(d => d.AppUserId == user.Id).ToList();

            var newStartDate = dayOffDto.StartDate;
            var newFinishDate = dayOffDto.FinishDate;

            if (userDayOffs.Any(existingDayOff => newStartDate <= existingDayOff.FinishDate && newFinishDate >= existingDayOff.StartDate))
            {
                return Response.Failure("There is a conflict with an existing day off request.");
            }

            // Yeni izin talebinin, daha önceki izinlerin arasında olup olmadığını kontrol et
            if (userDayOffs.Any(existingDayOff => newStartDate >= existingDayOff.StartDate && newStartDate <= existingDayOff.FinishDate) ||
                userDayOffs.Any(existingDayOff => newFinishDate >= existingDayOff.StartDate && newFinishDate <= existingDayOff.FinishDate))
            {
                // Çakışma var, uygun olmayan bir Response döndür
                return Response.Failure("The selected date range conflicts with an existing day off request.");
            }

            // Çakışma yok, uygun bir Response döndür
            return Response.Success();
        }
        private async Task<Response> RequestSoldierLeave(DayOffDto dayOffDto)
        {

           
            var user = await _userManager.FindByIdAsync(dayOffDto.AppUserId);
            var DayOffs = await GetAll();
            if (user == null)
            {
                return Response.Failure("User not found.");
            }
            var GengerDayoff = DayOffs.Context.Where( d => d.AppUserId==user.Id && d.Gender == Gender.Female || d.Gender == Gender.Male).FirstOrDefault();
            if (GengerDayoff != null)
            {
                dayOffDto.Gender = GengerDayoff.Gender;
            }
           
            var MaleOffs = DayOffs.Context.Where(d => d.AppUserId == user.Id && d.Gender == Gender.Male);
            if (!MaleOffs.Any() && dayOffDto.Gender==Gender.Female)
            {
                return Response.Failure("Famale users are not eligible for Maternity Day Off.");
            }
            var YearList = DayOffs.Context.Where(d => d.StartDate.Year == DateTime.Now.Year && d.DayOffType == DayOffType.SoldierLeave);
            if (YearList.Any())
            {
                return Response.Failure("You cannot take Paternity dayoff twice in the same year.");
            }
            var eligibilityResponse = await IsEligibleForNewDayOff(dayOffDto);

            if (!eligibilityResponse.IsSuccess)
            {
                return eligibilityResponse;
            }
            var waitingDayOff = DayOffs.Context.FirstOrDefault(d => d.AppUserId == user.Id && d.ConfirmStatus == ConfirmStatus.Waiting);
            if (waitingDayOff != null)
            {
                return Response.Failure("You already have a pending day off request. Please wait for confirmation.");
            }

            dayOffDto.DayCount = (float)(dayOffDto.FinishDate - dayOffDto.StartDate).TotalDays;
            dayOffDto.ConfirmStatus = ConfirmStatus.Waiting;
            dayOffDto.RequestDate = DateTime.Now;
            dayOffDto.Id = Guid.NewGuid().ToString();
            var result = await Insert(dayOffDto);

            return result.IsSuccess ? Response.Success() : Response.Failure("Failed to insert day off.");
        }
        private async Task<Response> RequestExcuseDayOff(DayOffDto dayOffDto)
        {
            var user = await _userManager.FindByIdAsync(dayOffDto.AppUserId);
            var DayOffs = await GetAll();
            if (user == null)
            {
                dayOffDto.DayCount += 0;
                return Response.Failure("User not found.");
            }
            var GengerDayoff = DayOffs.Context.Where(d => d.AppUserId == user.Id && d.Gender == Gender.Female || d.Gender == Gender.Male).FirstOrDefault();
            if (GengerDayoff != null)
            {
                dayOffDto.Gender = GengerDayoff.Gender;
            }
            var eligibilityResponse = await IsEligibleForNewDayOff(dayOffDto);

            if (!eligibilityResponse.IsSuccess)
            {
                return eligibilityResponse;
            }
            var waitingDayOff = DayOffs.Context.FirstOrDefault(d => d.AppUserId == user.Id && d.ConfirmStatus == ConfirmStatus.Waiting);
            if (waitingDayOff != null)
            {
                return Response.Failure("You already have a pending day off request. Please wait for confirmation.");
            }
            dayOffDto.ConfirmStatus = ConfirmStatus.Waiting;
            dayOffDto.DayCount = (float)(dayOffDto.FinishDate - dayOffDto.StartDate).TotalDays;
            dayOffDto.RequestDate = DateTime.Now;
            dayOffDto.Id = Guid.NewGuid().ToString();
            var result = await Insert(dayOffDto);

            return result.IsSuccess ? Response.Success() : Response.Failure("Failed to insert day off.");
        }
        private async Task<Response> RequestSickDayOff(DayOffDto dayOffDto)
        {
            var user = await _userManager.FindByIdAsync(dayOffDto.AppUserId);
            var DayOffs = await GetAll();
            if (user == null)
            {
                dayOffDto.DayCount += 0;
                return Response.Failure("User not found.");
            }
            var GengerDayoff = DayOffs.Context.Where(d => d.AppUserId == user.Id && d.Gender == Gender.Female || d.Gender == Gender.Male).FirstOrDefault();
            if (GengerDayoff != null)
            {
                dayOffDto.Gender = GengerDayoff.Gender;
            }
            var eligibilityResponse = await IsEligibleForNewDayOff(dayOffDto);

            if (!eligibilityResponse.IsSuccess)
            {
                return eligibilityResponse;
            }
            var waitingDayOff = DayOffs.Context.FirstOrDefault(d => d.AppUserId == user.Id && d.ConfirmStatus == ConfirmStatus.Waiting);
            if (waitingDayOff != null)
            {
                return Response.Failure("You already have a pending day off request. Please wait for confirmation.");
            }
            dayOffDto.ConfirmStatus = ConfirmStatus.Waiting;
            dayOffDto.DayCount = (float)(dayOffDto.FinishDate - dayOffDto.StartDate).TotalDays;
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
            var YearList = DayOffs.Context.Where(d => d.AppUserId == user.Id && d.StartDate.Year == DateTime.Now.Year && d.DayOffType == DayOffType.MarriageDayOff);
            if (YearList.Any())
            {
                return Response.Failure("You cannot take Marriage dayoff twice in the same year.");
            }
            var GengerDayoff = DayOffs.Context.Where(d => d.AppUserId == user.Id && d.Gender == Gender.Female || d.Gender == Gender.Male).FirstOrDefault();
            if (GengerDayoff != null)
            {
                dayOffDto.Gender = GengerDayoff.Gender;
            }
            var eligibilityResponse = await IsEligibleForNewDayOff(dayOffDto);

            if (!eligibilityResponse.IsSuccess)
            {
                return eligibilityResponse;
            }
            var waitingDayOff = DayOffs.Context.FirstOrDefault(d => d.AppUserId == user.Id && d.ConfirmStatus == ConfirmStatus.Waiting);
            if (waitingDayOff != null)
            {
                return Response.Failure("You already have a pending day off request. Please wait for confirmation.");
            }
            dayOffDto.FinishDate = dayOffDto.StartDate.AddDays(7);
            dayOffDto.DayCount = 7;
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
            var GengerDayoff = DayOffs.Context.Where(d => d.AppUserId == user.Id && d.Gender == Gender.Female || d.Gender == Gender.Male).FirstOrDefault();
            if (GengerDayoff != null)
            {
                dayOffDto.Gender = GengerDayoff.Gender;
            }
            var eligibilityResponse = await IsEligibleForNewDayOff(dayOffDto);

            if (!eligibilityResponse.IsSuccess)
            {
                return eligibilityResponse;
            }
            var waitingDayOff = DayOffs.Context.FirstOrDefault(d => d.AppUserId == user.Id && d.ConfirmStatus == ConfirmStatus.Waiting);
            if (waitingDayOff != null)
            {
                return Response.Failure("You already have a pending day off request. Please wait for confirmation.");
            }
            dayOffDto.FinishDate = dayOffDto.StartDate.AddHours(2);
            dayOffDto.DayCount = 2 / 24;
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

            var GengerDayoff = DayOffs.Context.Where(d => d.AppUserId == user.Id && d.Gender == Gender.Female || d.Gender == Gender.Male).FirstOrDefault();
            if (GengerDayoff != null)
            {
                dayOffDto.Gender = GengerDayoff.Gender;
            }
            var eligibilityResponse = await IsEligibleForNewDayOff(dayOffDto);

            if (!eligibilityResponse.IsSuccess)
            {
                return eligibilityResponse;
            }
            var waitingDayOff = DayOffs.Context.FirstOrDefault(d => d.AppUserId == user.Id && d.ConfirmStatus == ConfirmStatus.Waiting);
            if (waitingDayOff != null)
            {
                return Response.Failure("You already have a pending day off request. Please wait for confirmation.");
            }
            dayOffDto.FinishDate = dayOffDto.StartDate.AddDays(7);
            dayOffDto.DayCount = 7;
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
            var GengerDayoff = DayOffs.Context.Where(d => d.AppUserId == user.Id && d.Gender == Gender.Female || d.Gender == Gender.Male).FirstOrDefault();
            if (GengerDayoff != null)
            {
                dayOffDto.Gender = GengerDayoff.Gender;
            }
            var femaleDayOffs = DayOffs.Context.Where(d => d.Gender == Gender.Female);
            if (!femaleDayOffs.Any() && dayOffDto.Gender==Gender.Male)
            {
                return Response.Failure("Male users are not eligible for Maternity Day Off.");
            }
            var YearList = DayOffs.Context.Where(d => d.StartDate.Year == DateTime.Now.Year && d.DayOffType == DayOffType.MaternityDayOff);
            if (YearList.Any())
            {
                return Response.Failure("You cannot take Maternity dayoff twice in the same year.");
            }
            var eligibilityResponse = await IsEligibleForNewDayOff(dayOffDto);

            if (!eligibilityResponse.IsSuccess)
            {
                return eligibilityResponse;
            }
            var waitingDayOff = DayOffs.Context.FirstOrDefault(d => d.AppUserId == user.Id && d.ConfirmStatus == ConfirmStatus.Waiting);
            if (waitingDayOff != null)
            {
                return Response.Failure("You already have a pending day off request. Please wait for confirmation.");
            }
            dayOffDto.FinishDate = dayOffDto.StartDate.AddDays(49);
            dayOffDto.ConfirmStatus = ConfirmStatus.Waiting;
            dayOffDto.DayCount = 49;
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
            var MaleOffs = DayOffs.Context.Where(d => d.AppUserId == user.Id && d.Gender == Gender.Male);
            if (!MaleOffs.Any()&& dayOffDto.Gender==Gender.Female)
            {
                return Response.Failure("Famale users are not eligible for Maternity Day Off.");
            }
            var YearList = DayOffs.Context.Where(d => d.StartDate.Year == DateTime.Now.Year && d.DayOffType == DayOffType.PaternityDayOff);
            if (YearList.Any())
            {
                return Response.Failure("You cannot take Paternity dayoff twice in the same year.");
            }
            var GengerDayoff = DayOffs.Context.Where(d => d.AppUserId == user.Id && d.Gender == Gender.Female || d.Gender == Gender.Male).FirstOrDefault();
            if (GengerDayoff != null)
            {
                dayOffDto.Gender = GengerDayoff.Gender;
            }
            var eligibilityResponse = await IsEligibleForNewDayOff(dayOffDto);

            if (!eligibilityResponse.IsSuccess)
            {
                return eligibilityResponse;
            }
            var waitingDayOff = DayOffs.Context.FirstOrDefault(d => d.AppUserId == user.Id && d.ConfirmStatus == ConfirmStatus.Waiting);
            if (waitingDayOff != null)
            {
                return Response.Failure("You already have a pending day off request. Please wait for confirmation.");
            }
            dayOffDto.FinishDate = dayOffDto.StartDate.AddDays(7);
            dayOffDto.DayCount = 7;
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
            var DayOffs = await GetAll();
            var GengerDayoff = DayOffs.Context.Where(d => d.AppUserId == user.Id && d.Gender == Gender.Female || d.Gender == Gender.Male).FirstOrDefault();
            if (GengerDayoff != null)
            {
                dayOffDto.Gender = GengerDayoff.Gender;
            }
            var eligibilityResponse = await IsEligibleForNewDayOff(dayOffDto);

            if (!eligibilityResponse.IsSuccess)
            {
                return eligibilityResponse;
            }
            var waitingDayOff = DayOffs.Context.FirstOrDefault(d => d.AppUserId == user.Id && d.ConfirmStatus == ConfirmStatus.Waiting);
            if (waitingDayOff != null)
            {
                return Response.Failure("You already have a pending day off request. Please wait for confirmation.");
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

