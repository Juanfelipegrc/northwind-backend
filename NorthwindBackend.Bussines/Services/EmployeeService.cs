using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NorthwindBackend.Bussines.Interfaces;
using NorthwindBackend.Data.Context;
using NorthwindBackend.Data.ResultViews;
using NorthwindBackend.Bussines.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.Bussines.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeesSalesDTO>> GetTop3EmployeesBySalesAmount()
        {
            return await _context.EmployeeSalesDTOs
                .FromSqlRaw("EXEC GetTopEmployeesBySalesAmount")
                .ToListAsync();
        }

        public async Task<SPStatusResultDTO> CreateEmployeeAsync(CreateEmployeeRequestDTO request)
        {
            var result = (await _context.SPStatusResultDTOs.FromSqlRaw(
                "EXEC CreateNewEmployee @LastName, @FirstName, @Title, @TitleOfCourtesy, @BirthDate, @HireDate, @Address, @City, @Region, @PostalCode, @Country, @HomePhone, @Extension, @Photo, @Notes, @ReportsTo, @PhotoPath, @UserRequestId",
                    new[]
                    {
                        new SqlParameter("@LastName", request.LastName ?? (object)DBNull.Value),
                        new SqlParameter("@FirstName", request.FirstName ?? (object)DBNull.Value),
                        new SqlParameter("@Title", request.Title ?? (object)DBNull.Value),
                        new SqlParameter("@TitleOfCourtesy", request.TitleOfCourtesy ?? (object)DBNull.Value),
                        new SqlParameter("@BirthDate", request.BirthDate),
                        new SqlParameter("@HireDate", request.HireDate),
                        new SqlParameter("@Address", request.Address ?? (object)DBNull.Value),
                        new SqlParameter("@City", request.City ?? (object)DBNull.Value),
                        new SqlParameter("@Region", request.Region ?? (object)DBNull.Value),
                        new SqlParameter("@PostalCode", request.PostalCode ?? (object)DBNull.Value),
                        new SqlParameter("@Country", request.Country ?? (object)DBNull.Value),
                        new SqlParameter("@HomePhone", request.HomePhone ?? (object)DBNull.Value),
                        new SqlParameter("@Extension", request.Extension ?? (object)DBNull.Value),
                        new SqlParameter("@Photo", System.Data.SqlDbType.Image)
                        {
                            Value = (object?)request.Photo ?? DBNull.Value
                        },
                        new SqlParameter("@Notes", request.Notes ?? (object)DBNull.Value),
                        new SqlParameter("@ReportsTo", request.ReportsTo ?? (object)DBNull.Value),
                        new SqlParameter("@PhotoPath", request.PhotoPath ?? (object)DBNull.Value),
                        new SqlParameter("@UserRequestId", request.UserRequestId)
                    }
                ).ToListAsync()).FirstOrDefault();

            if(result == null)
            {
                return new SPStatusResultDTO { Success = false, Message = "Operation did not return any result" };
            }

            return result;
            
        }

        public async Task<SPStatusResultDTO> UpdateEmployeeAsync(int id, UpdateEmployeeRequestDTO request)
        {
            var result = (await _context.SPStatusResultDTOs.FromSqlRaw(
                "EXEC UpdateEmployeeById @EmployeeId, @UserRequestId, @LastName, @FirstName, @Title, @TitleOfCourtesy, @BirthDate, @HireDate, @Address, @City, @Region, @PostalCode, @Country, @HomePhone, @Extension, @Photo, @Notes, @ReportsTo, @PhotoPath",
                new[]
                {
                    new SqlParameter("@EmployeeId", id),
                    new SqlParameter("@UserRequestId", request.UserRequestId),
                    new SqlParameter("@LastName", (object?)request.LastName ?? DBNull.Value),
                    new SqlParameter("@FirstName", (object?)request.FirstName ?? DBNull.Value),
                    new SqlParameter("@Title", (object?)request.Title ?? DBNull.Value),
                    new SqlParameter("@TitleOfCourtesy", (object?)request.TitleOfCourtesy ?? DBNull.Value),
                    new SqlParameter("@BirthDate", (object?)request.BirthDate ?? DBNull.Value),
                    new SqlParameter("@HireDate", (object?)request.HireDate ?? DBNull.Value),
                    new SqlParameter("@Address", (object?)request.Address ?? DBNull.Value),
                    new SqlParameter("@City", (object?)request.City ?? DBNull.Value),
                    new SqlParameter("@Region", (object?)request.Region ?? DBNull.Value),
                    new SqlParameter("@PostalCode", (object?)request.PostalCode ?? DBNull.Value),
                    new SqlParameter("@Country", (object?)request.Country ?? DBNull.Value),
                    new SqlParameter("@HomePhone", (object?)request.HomePhone ?? DBNull.Value),
                    new SqlParameter("@Extension", (object?)request.Extension ?? DBNull.Value),
                    new SqlParameter("@Photo", System.Data.SqlDbType.Image)
                    {
                        Value = (object?)request.Photo ?? DBNull.Value
                    },
                    new SqlParameter("@Notes", (object?)request.Notes ?? DBNull.Value),
                    new SqlParameter("@ReportsTo", (object?)request.ReportsTo ?? DBNull.Value),
                    new SqlParameter("@PhotoPath", (object?)request.PhotoPath ?? DBNull.Value)
                }
            ).ToListAsync()).FirstOrDefault();

            if (result == null)
            {
                return new SPStatusResultDTO { Success = false, Message = "Operation did not return any result" };
            }
            return result;

        }


        public async Task<SPStatusResultDTO> DeleteEmployeeById(int id, int userRequestId)
        {
            var result = (await _context.SPStatusResultDTOs.FromSqlRaw(
                "EXEC DeleteEmployeeById @EmployeeId, @UserRequestId",
                new[]
                {
                    new SqlParameter("@EmployeeId", id),
                    new SqlParameter("@UserRequestId", userRequestId)
                }
            ).ToListAsync()).FirstOrDefault();

            if (result == null)
            {
                return new SPStatusResultDTO { Success = false, Message = "Operation did not return any result" };
            }
            return result;
        }

        public async Task<SPStatusResultDTO> DisableEmployeeById(int id, int userRequestId)
        {



            var result = (await _context.SPStatusResultDTOs.FromSqlRaw(
                "EXEC DisableEmployeeById @EmployeeId, @UserRequestId",
                new[]
                {
                    new SqlParameter("@EmployeeId", id),
                    new SqlParameter("@UserRequestId", userRequestId)
                }
            ).ToListAsync()).FirstOrDefault();

            if (result == null)
            {
                return new SPStatusResultDTO { Success = false, Message = "Operation did not return any result" };
            }
            return result;
        }

        public async Task<SPStatusResultDTO> EnableEmployeeById(int id, int userRequestId)
        {
            var result = (await _context.SPStatusResultDTOs.FromSqlRaw(
                "EXEC EnableEmployeeById @EmployeeId, @UserRequestId",
                new[]
                {
                    new SqlParameter("@EmployeeId", id),
                    new SqlParameter("@UserRequestId", userRequestId)
                }
            ).ToListAsync()).FirstOrDefault();

            if (result == null)
            {
                return new SPStatusResultDTO { Success = false, Message = "Operation did not return any result" };
            }
            return result;
        }

        public async Task<SPValidateDisabledUserResultDTO> ValidateDisabledEmployee(int id)
        {
            var result = (await _context.SPValidateDisabledUserResultDTOs.FromSqlRaw(
                "EXEC ValidateDisabledEmployee @EmployeeId",
                new[]
                {
                    new SqlParameter("@EmployeeId", id)
                } 
            ).ToListAsync()).FirstOrDefault();

            if (result == null)
            {
                return new SPValidateDisabledUserResultDTO { Success = false, Message = "Operation did not return any result" };
            }
            return result;
        }
    }
}
