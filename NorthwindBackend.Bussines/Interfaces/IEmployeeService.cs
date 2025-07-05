using NorthwindBackend.Data.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Bussines.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeesSalesDTO>> GetTop3EmployeesBySalesAmount();
        Task<bool> CreateEmployeeAsync(CreateEmployeeRequestDTO request);
        Task<bool> UpdateEmployeeAsync(int id, UpdateEmployeeRequestDTO request);
        Task<bool> DeleteEmployeeById(int id, int userRequestId);
        Task<bool> DisableEmployeeById(int id, int userRequestId);
        Task<bool> EnableEmployeeById(int id, int userRequestId);
        Task<bool> ValidateDisabledEmployee(int id);
    }
}
