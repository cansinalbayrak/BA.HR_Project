using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrasturucture.RequestResponse;
using BA.HR_Project.Infrasturucture.Services.Abstract;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Infrastructure.Services.Abstract
{
    public interface IAdvanceService:IService<Advance,AdvanceDto>
    {
        Task<Response> CreateAvance(AdvanceDto dto);
        Task<List<AdvanceDto>> GetAllAvance(string userId);
        Task<List<AdvanceDto>> AllUserAdvance();
        Task<Response> ApprovedAdvance(string id);
        Task<Response> RejectAdvance(string id);
    }
}
