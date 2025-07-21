using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Bussines.DTOs.Request
{
    public interface CreateUserRequestDTO
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string? Title { get; set; }

        public string? TitleOfCourtesy { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Country { get; set; }

        public string HomePhone { get; set; }
    }
}
