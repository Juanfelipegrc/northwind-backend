using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Data.DTO_s
{
    public class EmployeesSalesDTO
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string Country { get; set; } = "";
        public decimal TotalAmount { get; set; }
    }
}
