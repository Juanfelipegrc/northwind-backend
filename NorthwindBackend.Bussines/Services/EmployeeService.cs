using AutoMapper;
using NorthwindBackend.Bussines.DTOs.Request;
using NorthwindBackend.Bussines.DTOs.Response;
using NorthwindBackend.Bussines.DTOs.ResultViews;
using NorthwindBackend.Bussines.Interfaces.IQueries;
using NorthwindBackend.Bussines.Interfaces.IServices;
using NorthwindBackend.Domain.Entities;
using NorthwindBackend.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Bussines.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeQueries _employeeQueries;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeQueries employeeQueries, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _employeeQueries = employeeQueries;
            _mapper = mapper;
        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);

            var employeeMapped = _mapper.Map<EmployeeDTO>(employee);

            return employeeMapped;
        }

        public async Task<List<EmployeesSalesDTO>> GetTop3EmployeesBySalesAmount()
        {
            var emplooyess = await _employeeQueries.GetTop3EmployeesBySalesAmount();

            return emplooyess;
        }

        public async Task<SPStatusResultDTO> CreateEmployeeAsync(CreateEmployeeRequestDTO request)
        {
            var result = await _employeeQueries.CreateEmployeeAsync(request);

            return result;
        }

        public async Task<SPStatusResultDTO> UpdateEmployeeAsync(int id, UpdateEmployeeRequestDTO request)
        {
            var result = await _employeeQueries.UpdateEmployeeAsync(id, request);

            return result;
        }

        public async Task<SPStatusResultDTO> DeleteEmployeeById(int id, int userRequestId)
        {
            var result = await _employeeQueries.DeleteEmployeeById(id, userRequestId);

            return result;
        }

        public async Task<SPStatusResultDTO> DisableEmployeeById(int id, int userRequestId)
        {
            var result = await _employeeQueries.DisableEmployeeById(id, userRequestId);

            return result;
        }

        public async Task<SPStatusResultDTO> EnableEmployeeById(int id, int userRequestId)
        {
            var result = await _employeeQueries.EnableEmployeeById(id, userRequestId);

            return result;
        }

        public async Task<SPValidateDisabledUserResultDTO> ValidateDisabledEmployee(int id)
        {
            var result = await _employeeQueries.ValidateDisabledEmployee(id);

            return result;
        }


    }
}
