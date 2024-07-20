using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using EmployeeRequestTrackerAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly KeyVaultService _keyVaultService;

        public EmployeeController(IEmployeeService employeeService, KeyVaultService keyVaultService) {
             _employeeService = employeeService;
            _keyVaultService = keyVaultService;

        }
        [Route("GetAllEmployees")]
        [HttpGet]
        [ProducesResponseType(typeof(IList<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<RegisterOutputDTO>>> Get()
        {
            try
            {
                var employees = await _employeeService.GetEmployees();
                Console.WriteLine(_keyVaultService.GetSecretAsync("constringdb3"));
                return Ok(employees.ToList());
            }
            catch (NoEmployeesFoundException nefe)
            {
                return NotFound(new ErrorModel(404, nefe.Message));
            }
        }
        [Route("UpdateEmployeePhone")]
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<RegisterOutputDTO>> Put(int id, string phone)
        {
            try
            {
                var employee = await _employeeService.UpdateEmployeePhone(id, phone);
                return Ok(employee);
            }
            catch (NoSuchEmployeeException nsee)
            {
                return NotFound(nsee.Message);
            }
        }
        [Route("GetEmployeeByPhone")]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<RegisterOutputDTO>> Get([FromBody] string phone)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByPhone(phone);
                return Ok(employee);
            }
            catch (NoSuchEmployeeException nefe)
            {
                return NotFound(nefe.Message);
            }
        }
    }
}
