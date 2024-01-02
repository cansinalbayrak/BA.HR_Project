using BA.HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Application.DTOs
{
    public class ExpenseDto : IDTO
    {
        public string Id { get; set; }
        public string RequestNumber { get; set; }
        public float RequestPrice { get; set; }
        public float ExpenseMaxPrice { get; set; }
        public float ExpenseMinPrice { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ReplyDate { get; set; }
        public string? PhotoPath { get; set; }
        public string? FilePath { get; set; }
        public ConfirmStatus ConfirmStatus { get; set; }
        public Currency Currency { get; set; }
    }
}
