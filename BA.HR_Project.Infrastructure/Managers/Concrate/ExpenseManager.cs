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
            var user = _userManager.FindByIdAsync(dto.Id);

            var expenseType = await _expenseTypeService.FindExpenseTypeAsync(dto.ExpenseTypeId);

            if (dto.RequestPrice >= expenseType.ExpenseMinPrice  && dto.RequestPrice <= expenseType.ExpenseMaxPrice)
            {

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
            return Response.Failure("You should correct request price value with between maxprice value and minprice value. ");
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
        public async Task<List<ExpenseDto>> AllUserExpense()
        {
            var expensesAction = await GetAll();
            var userExpenses = expensesAction.Context.OrderBy(x => x.RequestDate).ToList();
            return userExpenses;
        }
        public async Task<Response> ApprovedExpense(string id)
        {
            var expenseAction = await GetByIdAsync(id);
            var expense = expenseAction.Context;
            if (expense != null)
            {
                expense.ConfirmStatus = ConfirmStatus.Approved;
                expense.ReplyDate = DateTime.Now;
                await Update(expense);
                return Response.Success();
            }
            return Response.Failure("Expense not found");
        }
        public async Task<Response> RejectExpense(string id)
        {
            var expenseAction = await GetByIdAsync(id);
            var expense = expenseAction.Context;
            if (expense != null)
            {
                expense.ConfirmStatus = ConfirmStatus.Denied;
                expense.ReplyDate = DateTime.Now;
                await Update(expense);
                return Response.Success();
            }
            return Response.Failure("Expense not found");
        }
    }
}
