﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Bussines.DTOs.Request
{
    public class CreateEmployeeRequestDTO
    {
        public string LastName { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string Title { get; set; } = "";
        public string TitleOfCourtesy { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string Region { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public string Country { get; set; } = "";
        public string HomePhone { get; set; } = "";
        public string Extension { get; set; } = "";
        public byte[]? Photo { get; set; } = null;
        public string Notes { get; set; } = "";
        public int? ReportsTo { get; set; }
        public string? PhotoPath { get; set; } = null;
        public int UserRequestId { get; set; }
    }
}
