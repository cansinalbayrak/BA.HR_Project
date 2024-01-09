using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrasturucture.RequestResponse;
using BA.HR_Project.Infrasturucture.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Infrastructure.Services.Concrate
{
    public interface IExpsenseService : IService<Expense,ExpenseDto>
    {
        Task<Response> RequestExpense(ExpenseDto dto);
        Task<List<ExpenseDto>> GetAllExpenses(string userId);
         Task<Response> RejectExpense(string id);
        Task<Response> ApprovedExpense(string id);
        Task<List<ExpenseDto>> AllUserExpense();

    }
}
