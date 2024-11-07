using Employee_Test.Data;
using Employee_Test.Employees;
using Employee_Test.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDepartmentMappingController : ControllerBase
    {
        private readonly EmployeeDepartmentMappingService _mappingService;

        public EmployeeDepartmentMappingController(EmployeeDepartmentMappingService mappingService)
        {
            this._mappingService = mappingService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateMapping([FromBody] CreateMappingDto dto)
        {
            var mapping = await _mappingService.CreateMapping(dto.EmployeeId, dto.DepartmentId, dto.StartDate, dto.EndDate);
            return Ok(mapping);
        }

        [HttpGet("AllMapping")]
        public async Task<IActionResult> GetMappings()
        {
            var mappings = await _mappingService.GetMappings();
            return Ok(mappings);
        }

      
    }
}
