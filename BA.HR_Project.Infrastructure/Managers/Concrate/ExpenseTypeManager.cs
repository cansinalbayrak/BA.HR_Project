using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Application.Interfaces;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrastructure.Services.Concrate;
using BA.HR_Project.Infrasturucture.Managers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Infrastructure.Managers.Concrate
{
    public class ExpenseTypeManager : BaseManager<ExpenseType, ExpenseTypeDto>, IExpenseTypeService
    {
        public ExpenseTypeManager(IMapper mapper, IUow uow) : base(mapper, uow)
        {
        }

        public async Task<float> CalculateMaxPrice(ExpenseType expenseType)
        {
            float MaxPrice = (expenseType.MainPrice * expenseType.MaxFactor) + expenseType.MainPrice;
            return MaxPrice;
        }
        public async Task<float> CalculateMinPrice(ExpenseType expenseType)
        {
            float MinPrice = (expenseType.MainPrice  * expenseType.MinFactor) - expenseType.MainPrice;
            return MinPrice;
        }


    }
}
