using BA.HR_Project.Domain.Common;
using BA.HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Domain.Entities
{
    public class DayOff:IEntity
    {
        public DayOff()
        {
            Id = Guid.NewGuid().ToString();
            RequestDate = DateTime.Now;
        }
        public string Id { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime RequestDate { get; set; }
        public float? DayCount { get; set; }
        public ConfirmStatus ConfirmStatus { get; set; } = ConfirmStatus.Waiting;
        public Gender Gender { get; set; }
        public DateTime? ResponseDate { get; set; }
        public string AppUserId { get; set; }
        public DayOffType DayOffType { get; set; }

        #region Navigation Property
        public AppUser AppUser { get; set; }

        #endregion
    }
}
