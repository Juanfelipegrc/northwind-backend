using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Data.DTO_s
{
    public class DisableEmployeeRequestDTO
    {
        public int EmployeeId { get; set; }
        public int UserRequestId { get; set; }
    }
}
