using Employee_Test.Models;
using Employee_Test.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Employee_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentRepository _departmentRepository;

        public DepartmentController(DepartmentRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
            
        }
        [HttpGet("DepartmentList")]
        public async Task<ActionResult> DepartmentList()
        {
            var data =  await _departmentRepository.GetDepartments();
            return Ok(data);
        }

        [HttpPost("AddDepartment")]
        public async Task<ActionResult> AddDepartment(Department dept)
        {
            await _departmentRepository.SaveDepartments(dept);
            return Ok(dept);
        }

        [HttpPut("UpdateDepartment/{id}")]
        public async Task<ActionResult> UpdateDepartment(int id, Department dept)
        {
            await _departmentRepository.UpdateDepartment(id, dept);
            return Ok(dept);
        }

        [HttpDelete("DeleteDepartment/{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            await _departmentRepository.DeleteDepartment(id);
            return Ok();
        }
    }
}
