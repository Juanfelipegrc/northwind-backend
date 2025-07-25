﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Bussines.DTOs.Response
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Title { get; set; }
        public string? TitleOfCourtesy { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? HomePhone { get; set; }
    }
}
