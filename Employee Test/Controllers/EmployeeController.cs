using Employee_Test.Employees;
using Employee_Test.Models;
using Employee_Test.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Employee_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeController(EmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        [HttpGet("GetAllEmployee")]
        public async Task<ActionResult> EmployeeList()
        {
            var data = await _employeeRepository.GetEmployees();
            return Ok(data);
        }

        [HttpPost("AddEmployee")]
        public async Task<ActionResult> AddEmployee(Employee emp)
        {
            await _employeeRepository.SaveEmployee(emp);
            return Ok(emp);
        }










        [HttpPut("UpdateEmployee/{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] EmployeeUpdateDto emp)
        {
            await _employeeRepository.UpdateEmployee(id, emp);
            return Ok(emp);
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
            return Ok();
        }
       
    }
}
