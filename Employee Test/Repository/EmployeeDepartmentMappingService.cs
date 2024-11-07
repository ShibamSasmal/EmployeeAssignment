using Employee_Test.Data;
using Employee_Test.Models;

using Microsoft.EntityFrameworkCore;

namespace Employee_Test.Repository
{
    public class EmployeeDepartmentMappingService
    {
        private readonly AppDbContext _context;
        public EmployeeDepartmentMappingService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<EmployeeDepartmentMapping> CreateMapping(int employeeId, int departmentId, DateTime startDate, DateTime endDate)
        {
            var mapping = new EmployeeDepartmentMapping
            {
                EmployeeId = employeeId,
                DepartmentId = departmentId,
                StartDate = startDate,
                EndDate = endDate
            };

            _context.EmployeeDepartmentMapping.Add(mapping);
            await _context.SaveChangesAsync();

            return mapping;
        }
        public async Task<IEnumerable<EmployeeDepartmentMapping>> GetMappings()
        {
            return await _context.EmployeeDepartmentMapping
                                 .Include(m => m.Employee)   
                                 .Include(m => m.Department) 
                                 .ToListAsync();
        }

    }
}
