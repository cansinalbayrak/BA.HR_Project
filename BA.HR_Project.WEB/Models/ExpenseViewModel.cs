using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Domain.Enums;

namespace BA.HR_Project.WEB.Models
{
    public class ExpenseViewModel
    {
        public string Id { get; set; }
        public string RequestNumber { get; set; }
        public float RequestPrice { get; set; }

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

        public AppUserViewModel AppUser { get; set; }
        
    }
}
