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

namespace BA.HR_Project.Infrasturucture.Managers.Concrate
{
    public class DepartmentManager : BaseManager<Department,DepartmentDto>,IDepartmentService
    {
        public DepartmentManager(IMapper mapper, IUow uow) : base(mapper,uow)
        {
            
        }
    }
}
