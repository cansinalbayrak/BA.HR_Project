using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Domain.Enums;
using Microsoft.AspNetCore.Http;
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
        public decimal RequestPrice { get; set; }

        public DateTime RequestDate { get; set; }
        public DateTime? ReplyDate { get; set; }
        public IFormFile File { get; set; }

        public string? FilePath { get; set; }
        public ConfirmStatus ConfirmStatus { get; set; }
        public Currency Currency { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public string ExpenseTypeId { get; set; }
        public string ExpenseName { get; set; }
        public string AppUserId { get; set; }

        public AppUserDto AppUser { get; set; }
    }
}
