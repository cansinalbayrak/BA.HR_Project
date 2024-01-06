using BA.HR_Project.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Domain.Entities
{
    public class ExpenseType : IEntity
    {
        public ExpenseType()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get ; set; }
        public string ExpenseName { get; set; }
        
        public decimal ExpenseMaxPrice { get; set; }
        public decimal ExpenseMinPrice { get; set; }
        
        public IEnumerable<Expense> Expenses { get; set; }
    }
}
