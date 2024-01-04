using AutoMapper;
using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Application.Interfaces;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Infrastructure.Services.Concrate;
using BA.HR_Project.Infrasturucture.Managers.Abstract;
using BA.HR_Project.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Infrastructure.Managers.Concrate
{
    public class ExpenseTypeManager : BaseManager<ExpenseType, ExpenseTypeDto>, IExpenseTypeService
    {
        private readonly AppDbContext _context;
        public ExpenseTypeManager(IMapper mapper, IUow uow, AppDbContext context) : base(mapper, uow)
        {
            _context = context;
        }



        public List<ExpenseType> GetAll()
        {
            return _context.ExpenseTypes.ToList();
        }

        public List<ExpenseTypeCustom> GetAllCustomColumn()
        {
            return _context.ExpenseTypes.Select(e => new ExpenseTypeCustom { Id = e.Id, Name = (e.ExpenseName + " (" + e.ExpenseMinPrice + " - " + e.ExpenseMaxPrice + ") ") }).ToList();
        }

        public decimal GetMaxPrice(string id)
        {
            var maxPrice = _context.ExpenseTypes.Find(id).ExpenseMaxPrice;
            return maxPrice;
        }

        public decimal GetMinPrice(string id)
        {
            var minPrice = _context.ExpenseTypes.Find(id).ExpenseMinPrice;
            return minPrice; 
        }
    }

    public class ExpenseTypeCustom
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
