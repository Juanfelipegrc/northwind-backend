using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindBackend.Bussines.Interfaces.IServices;
using NorthwindBackend.Bussines.DTOs.Request;
using NorthwindBackend.Bussines.DTOs.Response;

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

        [HttpGet("get-employee-by-id/{employeeId}")]
        public async Task<IActionResult> GetEmployeeById(int employeeId)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeById(employeeId);

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
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

                if(result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(new { message = result.Message, success = result.Success });
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

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(new { message = result.Message, success = result.Success });
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

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(new { message = result.Message, success = result.Success });
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

                Console.WriteLine(result);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(new { message = result.Message, success = result.Success });
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

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(new { message = result.Message, success = result.Success });
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

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(new { message = result.Message, success = result.Success });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
