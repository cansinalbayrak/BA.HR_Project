using BA.HR_Project.Domain.Common;
using BA.HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Domain.Entities
{
    public class Expense : IEntity
    {
        public Expense()
        {
          Id = Guid.NewGuid().ToString();
            RequestDate= DateTime.Now;
            RequestNumber = Guid.NewGuid().ToString();


        }
        public string Id { get; set ; }
        public string RequestNumber { get; set; }
        public float RequestPrice { get; set; }
       
        public DateTime RequestDate { get; set; }
        public DateTime? ReplyDate { get; set; }
       
        public string? FilePath { get; set; }
        public ConfirmStatus ConfirmStatus { get; set; }
        public Currency Currency { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public string ExpenseTypeId { get; set; }
        public string ExpenseName { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        
    }
}
