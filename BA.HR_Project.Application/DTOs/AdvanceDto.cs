using BA.HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Application.DTOs
{
    public class AdvanceDto:IDTO
    {
        public string Id { get; set; }
        public AdvanceType AdvanceType { get; set; }
        public ConfirmStatus ConfirmStatus { get; set; } 
        public int Amount { get; set; }
        //public int? RemainingAmount { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public Currency Currency { get; set; }
        public string? Description { get; set; }
        public string AppUserId { get; set; }
        #region NavProp
        public AppUserDto AppUserDto { get; set; }
        #endregion
    }
}
