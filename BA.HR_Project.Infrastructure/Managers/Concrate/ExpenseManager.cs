using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Application.Interfaces;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Domain.Enums;
using BA.HR_Project.Infrastructure.Services.Concrate;
using BA.HR_Project.Infrasturucture.Managers.Abstract;
using BA.HR_Project.Infrasturucture.RequestResponse;
using BA.HR_Project.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly AppDbContext _appDbContext;
        private readonly IExpenseTypeService _expenseTypeService;

        public ExpenseManager(IMapper mapper, IUow uow, UserManager<AppUser> userManager, AppDbContext appDbContext, IExpenseTypeService expenseTypeService) : base(mapper, uow)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
            _expenseTypeService = expenseTypeService;
        }

        public async Task<Response> RequestExpense(ExpenseDto dto)
        {
            //if(dto.RequestPrice >= dto.ExpenseType.ExpenseMinPrice && dto.RequestPrice <= dto.ExpenseType.ExpenseMaxPrice)
            //{
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
            //}
            //return Response.Failure("Error");
        }
        public async Task<List<ExpenseDto>> GetAllExpenses(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var expenses = await GetAll();
            var expenseTypes = _expenseTypeService.GetAllCustomColumn();
            var ExpenseAction = expenses.Context.AsQueryable().Include(e=>e.ExpenseType).Where(e=>e.AppUserId==userId)
                .OrderBy(e=>e.RequestDate).ToList();
            //var ExpenseAction = expenses.Context.Where(e=>e.AppUserId== userId).OrderBy(x=>x.RequestDate).ToList();
            return ExpenseAction;


        }
    }
}
