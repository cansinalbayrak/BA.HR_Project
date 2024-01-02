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
        public float MainPrice { get; set; }
        public float MinFactor { get; set; }
        public float MaxFactor { get; set; }
        public string ExpenseId { get; set; }
        public Expense Expense { get; set; }
    }
}
