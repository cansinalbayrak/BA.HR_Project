using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Application.Interfaces;
using BA.HR_Project.Infrasturucture.Managers.Abstract;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using BA.HR_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BA.HR_Project.Persistance.Context;
using BA.HR_Project.Infrasturucture.RequestResponse;

namespace BA.HR_Project.Infrasturucture.Managers.Concrate
{
    public class CompanyManager : BaseManager<Company, CompanyDto>, ICompanyService
    {
        private readonly AppDbContext _appDbContext;
        public CompanyManager(IMapper mapper, IUow uow, AppDbContext appDbContext) : base(mapper, uow)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Response> AddCompany(CompanyDto companyDto)
        {
            if (IsMersisNoOrTaxNoAvailable(companyDto.MersisNo, companyDto.TaxNo))
            {
                return Response.Failure("MersisNo and TaxNo is already in use by another company.");
            }
            else
            {
                var result= await Insert(companyDto);
                return result.IsSuccess ? Response.Success() : Response.Failure("Failed to insert Company.");
            }

        }
        public bool IsMersisNoOrTaxNoAvailable(string mersisNo, string taxNo, string companyId = null)
        {
            var existingCompany = _appDbContext.Companies.FirstOrDefault(c => c.Id != companyId && (c.MersisNo == mersisNo && c.TaxNo == taxNo));

            // Eğer existingCompany null değilse, aynı MersisNo veya TaxNo'ya sahip başka bir şirket var demektir
            return existingCompany == null;
        }

        public List<CompanyCustom> GetAllCompanyCustomColumn()
        {
            return _appDbContext.Companies
                        .AsEnumerable() 
                        .Select(c => new CompanyCustom { Id = c.Id.ToString(), CompanyName = c.Name })
                        .ToList();
        }

        
    }
    public class CompanyCustom
    {
 
        public string Id { get; set; }
        public string CompanyName { get; set; }
   
    }
}
