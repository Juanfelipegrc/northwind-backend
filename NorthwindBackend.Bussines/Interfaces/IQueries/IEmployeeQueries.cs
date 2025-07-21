using NorthwindBackend.Bussines.DTOs.Request;
using NorthwindBackend.Bussines.DTOs.ResultViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Bussines.Interfaces.IQueries
{
    public interface IEmployeeQueries
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
