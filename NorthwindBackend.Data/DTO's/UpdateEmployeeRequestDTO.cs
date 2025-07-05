using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Data.DTO_s
{
    public class UpdateEmployeeRequestDTO
    {
        public string? LastName { get; set; } = null;
        public string? FirstName { get; set; } = null;
        public string? Title { get; set; } = null;
        public string? TitleOfCourtesy { get; set; } = null;
        public DateTime? BirthDate { get; set; } = null;
        public DateTime? HireDate { get; set; } = null;
        public string? Address { get; set; } = null;
        public string? City { get; set; } = null;
        public string? Region { get; set; } = null;
        public string? PostalCode { get; set; } = null;
        public string? Country { get; set; } = null;
        public string? HomePhone { get; set; } = null;
        public string? Extension { get; set; } = null;
        public byte[]? Photo { get; set; } = null;
        public string? Notes { get; set; } = null;
        public int? ReportsTo { get; set; } = null;
        public string? PhotoPath { get; set; } = null;
        public int UserRequestId { get; set; }
    }
}
