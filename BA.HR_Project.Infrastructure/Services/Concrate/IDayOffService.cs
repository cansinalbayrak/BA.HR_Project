using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Domain.Enums;
using BA.HR_Project.Infrasturucture.RequestResponse;
using BA.HR_Project.Infrasturucture.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Infrastructure.Services.Concrate
{
    public interface IDayOffService : IService<DayOff, DayOffDto>
    {
        public Task<Response> RequestDayOff( DayOffDto dayOffDto);
        public  Task<List<DayOffDto>> GetAllDayOff(string userId);
        public Task<List<DayOffDto>> WaitingDayOffs(string UserId);
        public Task<List<DayOffDto>> ApprovedDayOffs(string UserId);
        public Task<List<DayOffDto>> DeniedDayOffs(string UserId);
      
        Task<List<DayOffDto>> AllUserDayOff();
        Task<Response> ApprovedDayOff(string id);
        Task<Response> RejectDayOff(string id);
    }
}
