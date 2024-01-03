using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Application.Interfaces;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrastructure.Services.Concrate;
using BA.HR_Project.Infrasturucture.Managers.Abstract;
using BA.HR_Project.Infrasturucture.RequestResponse;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Infrastructure.Managers.Concrate
{
    
    public class ExpenseManager : BaseManager<Expense, ExpenseDto>, IExpsenseService
    {
      
        public ExpenseManager(IMapper mapper, IUow uow ) : base(mapper, uow)
        {
            
        }

       
    }
}
