using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindBackend.Bussines.Interfaces;
using NorthwindBackend.Data.DTO_s;

namespace NorthwindBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }

        [HttpGet("get-top3-employees-by-sales")]
        public async Task<IActionResult> GetTop3EmployeesBySalesAmount()
        {
            try
            {
                var top3Employees = await _employeeService.GetTop3EmployeesBySalesAmount();

                return Ok(top3Employees);
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("create-employee")]
        public async Task<IActionResult> CreateEmployeeAsync([FromBody] CreateEmployeeRequestDTO request)
        {
            try
            {
                var result = await _employeeService.CreateEmployeeAsync(request);

                if(result)
                {
                    return Ok(new { message = "Employee created successfully" });
                }
                else
                {
                    return BadRequest(new { message = "Error creating Employee, User don't have authorization" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("update-employee/{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeByIdAsync(int employeeId, [FromBody] UpdateEmployeeRequestDTO request)
        {
            try
            {
                var result = await _employeeService.UpdateEmployeeAsync(employeeId, request);

                if (result)
                {
                    return Ok(new { message = "Employee updated successfully" });
                }
                else
                {
                    return BadRequest(new { message = "Error updating Employee, User don't have authorization" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("delete-employee/{employeeId}")]
        public async Task<IActionResult> DeleteEmployeeByIdAsync(int employeeId, [FromQuery] int userRequestId)
        {
            try
            {
                var result = await _employeeService.DeleteEmployeeById(employeeId, userRequestId);

                if (result)
                {
                    return Ok(new { message = "Employee deleted successfully" });
                }
                else
                {
                    return BadRequest(new { message = "Error deleting Employee, User don't have authorization" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("disable-employee")]
        public async Task<IActionResult> DisableEmployeeByIdAsync([FromBody] DisableEmployeeRequestDTO request)
        {
            try
            {
                var result = await _employeeService.DisableEmployeeById(request.EmployeeId, request.UserRequestId);

                if (result)
                {
                    return Ok(new { message = "Employee disabled successfully" });
                }
                else
                {
                    return BadRequest(new { message = "Error disabling Employee, User don't have authorization" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("enable-employee")]
        public async Task<IActionResult> EnableEmployeeByIdAsync([FromBody] DisableEmployeeRequestDTO request)
        {
            try
            {
                var result = await _employeeService.EnableEmployeeById(request.EmployeeId, request.UserRequestId);

                if (result)
                {
                    return Ok(new { message = "Employee enabled successfully" });
                }
                else
                {
                    return BadRequest(new { message = "Error enabling Employee, User don't have authorization" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("validate-disabled-employee/{employeeId}")]
        public async Task<IActionResult> ValidateDisabledEmployee(int employeeId)
        {
            try
            {
                var result = await _employeeService.ValidateDisabledEmployee(employeeId);

                if (!result)
                {
                    return Ok(new 
                    { 
                        message = "Employee is not disabled",
                        isDisabled = false
                    });
                }
                else
                {
                    return Ok(new
                    {
                        message = "Employee is disabled",
                        isDisabled = true
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
