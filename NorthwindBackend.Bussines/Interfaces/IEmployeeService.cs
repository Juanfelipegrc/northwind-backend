using NorthwindBackend.Data.ResultViews;
using NorthwindBackend.Bussines.DTOs;
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
        Task<SPStatusResultDTO> CreateEmployeeAsync(CreateEmployeeRequestDTO request);
        Task<SPStatusResultDTO> UpdateEmployeeAsync(int id, UpdateEmployeeRequestDTO request);
        Task<SPStatusResultDTO> DeleteEmployeeById(int id, int userRequestId);
        Task<SPStatusResultDTO> DisableEmployeeById(int id, int userRequestId);
        Task<SPStatusResultDTO> EnableEmployeeById(int id, int userRequestId);
        Task<SPValidateDisabledUserResultDTO> ValidateDisabledEmployee(int id);
    }
}
