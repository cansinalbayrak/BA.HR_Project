using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrastructure.Managers.Concrate;
using BA.HR_Project.Infrasturucture.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Infrastructure.Services.Concrate
{
    public interface IExpenseTypeService : IService<ExpenseType, ExpenseTypeDto>
    {
        //Task Insert(ExpenseDto expenseDto);
        List<ExpenseType> GetAll();
        List<ExpenseTypeCustom> GetAllCustomColumn();
        //    decimal GetMinPrice(string id);
        //    decimal GetMaxPrice(string id);
        string GetName(string id);
        Task<ExpenseType> FindExpenseTypeAsync(string ExpenseTypeId);
    }
   
}
