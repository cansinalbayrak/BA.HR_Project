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

namespace BA.HR_Project.Infrasturucture.Managers.Concrate
{
    public class CompanyManager : BaseManager<Company, CompanyDto>, ICompanyService
    {
        private readonly AppDbContext _appDbContext;
        public CompanyManager(IMapper mapper, IUow uow, AppDbContext appDbContext) : base(mapper, uow)
        {
            _appDbContext = appDbContext;
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
