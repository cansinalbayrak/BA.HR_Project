using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Application.DTOs
{
    public class ExpenseTypeDto : IDTO
    {
        public string Id { get; set; }
        public string ExpenseName { get; set; }
        public float MainPrice { get; set; }
        public float MinFactor { get; set; }
        public float MaxFactor { get; set; }
    }
}
