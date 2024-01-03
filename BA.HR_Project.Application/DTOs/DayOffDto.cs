using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Application.DTOs
{
    public class DayOffDto:IDTO
    {
        public string Id { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime? RequestDate { get; set; }
        public float DayCount { get; set; }
        public ConfirmStatus? ConfirmStatus { get; set; } 
        public Gender Gender { get; set; }
        public DateTime? ResponseDate { get; set; }
        public string AppUserId { get; set; }
        public DayOffType DayOffType { get; set; }

        public AppUserDto AppUser { get; set; }
    }
}
