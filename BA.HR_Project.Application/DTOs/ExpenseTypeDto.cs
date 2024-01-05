using BA.HR_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Application.DTOs
{
    public class ExpenseTypeDto : IDTO
    {
        public string Id { get; set; }
        public string ExpenseName { get; set; }
       
        public decimal ExpenseMaxPrice { get; set; }
        public decimal ExpenseMinPrice { get; set; }
        public Expense? Expense { get; set; }
    }
}
