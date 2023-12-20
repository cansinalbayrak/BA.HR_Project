﻿using BA.HR_Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Application.DTOs
{
    public class ListSummaryInfoDto : IDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
        public string PhotoPath { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyId { get; set; }
        public string DepantmentId { get; set; }
        public Company Company { get; set; }
        public Department Department { get; set; }
        public Adress Adress { get; set; }


    }
}
