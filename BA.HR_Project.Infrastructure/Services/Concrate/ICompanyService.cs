using BA.HR_Project.Infrasturucture.Services.Abstract;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BA.HR_Project.Infrasturucture.RequestResponse;
using BA.HR_Project.Infrastructure.Managers.Concrate;
using BA.HR_Project.Infrasturucture.Managers.Concrate;

namespace BA.HR_Project.Infrasturucture.Services.Concrate
{
    public interface ICompanyService : IService<Company,CompanyDto>
    {
        List<CompanyCustom> GetAllCompanyCustomColumn();
        public Task<Response> AddCompany(CompanyDto companyDto);
        public Task<Response> IncreaseCompanyEmployeeCount(string CompanyId);
    }
}
