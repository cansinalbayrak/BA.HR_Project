using AutoMapper;
using BA.HR_Project.Infrasturucture.Managers.Abstract;
using BA.HR_Project.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Infrasturucture.Services.Concrate;
using BA.HR_Project.Persistance.Context;

namespace BA.HR_Project.Infrasturucture.Managers.Concrate
{
    public class DepartmentManager : BaseManager<Department,DepartmentDto>,IDepartmentService
    {
        private readonly AppDbContext _appDbContext;



        public DepartmentManager(IMapper mapper, IUow uow, AppDbContext appDbContext) : base(mapper, uow)
        {
            _appDbContext = appDbContext;
        }

        public List<DepartmentCustom> GetAllDepartmentCustomColumn()
        {
            return _appDbContext.Departments
                .AsEnumerable()
                .Select(d=>new DepartmentCustom {Id = d.Id ,DepartmentName = d.Name })
                .ToList();
        }

    }
    public class DepartmentCustom
    {

        public string Id { get; set; }
        public string DepartmentName { get; set; }

    }
}
