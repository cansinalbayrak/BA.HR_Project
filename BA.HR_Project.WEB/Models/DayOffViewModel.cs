using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Enums;

namespace BA.HR_Project.WEB.Models
{
    public class DayOffViewModel
    {

        public string Id { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public DateTime? RequestDate { get; set; }
        public float? DayCount { get; set; }
        public ConfirmStatus ConfirmStatus { get; set; }
        public Gender Gender { get; set; }
        public DateTime? ResponseDate { get; set; }
        public string AppUserId { get; set; }
        public DayOffType DayOffType { get; set; }

        public AppUserViewModel AppUser { get; set; }
        public string ErrorMsg { get; set; }
    }
}
