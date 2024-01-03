using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Application.Interfaces;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Domain.Enums;
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
        private readonly UserManager<AppUser> _userManager;

        public ExpenseManager(IMapper mapper, IUow uow, UserManager<AppUser> userManager) : base(mapper, uow)
        {
            _userManager = userManager;
        }

        public async Task<Response> RequestExpense(ExpenseDto dto)
        {
            var user = _userManager.FindByIdAsync(dto.Id);
            dto.RequestNumber = Guid.NewGuid().ToString();
            dto.Id = Guid.NewGuid().ToString();
            dto.ConfirmStatus = ConfirmStatus.Waiting;
            dto.RequestDate = DateTime.Now;
            var result = await Insert(dto);
            if (!result.IsSuccess) 
            {
                return Response.Failure("Error");
            
            }
            return Response.Success("Success");
        }
    }
}
