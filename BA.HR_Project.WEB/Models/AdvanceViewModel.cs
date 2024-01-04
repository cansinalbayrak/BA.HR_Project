using BA.HR_Project.Application.DTOs;
using BA.HR_Project.Domain.Enums;

namespace BA.HR_Project.WEB.Models
{
    public class AdvanceViewModel
    {
        public string Id { get; set; }
        public AdvanceType AdvanceType { get; set; }
        public ConfirmStatus ConfirmStatus { get; set; }
        public int? Amount { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public Currency Currency { get; set; }
        public string? Description { get; set; }
        public string AppUserId { get; set; }
        #region NavProp
        public AppUserViewModel AppUser { get; set; }
        #endregion
    }
}
