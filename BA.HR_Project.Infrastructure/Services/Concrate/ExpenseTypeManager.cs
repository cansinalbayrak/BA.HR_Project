using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Application.Interfaces;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrasturucture.Managers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Infrastructure.Services.Concrate
{
    public class ExpenseTypeManager : BaseManager<ExpenseType, ExpenseTypeDto>, IExpenseTypeService
    {
        public ExpenseTypeManager(IMapper mapper, IUow uow) : base(mapper, uow)
        {
        }

        public async Task<float> CalculateMaxPrice(float mainPrice, float maxFactor)
        {
            float MaxPrice =  (mainPrice * maxFactor) + mainPrice;
            return MaxPrice;
        }
        public async Task<float> CalculateMinPrice(float mainPrice, float minFactor)
        {
            float MinPrice = (mainPrice * minFactor) - mainPrice;
            return MinPrice;
        }

       
    }
}
