using Employee_Test.Data;
using Employee_Test.Employees;
using Employee_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Test.Repository
{
    public class EmployeeRepository
    {
        private readonly AppDbContext context;

        public EmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }

        //public async Task<List<Employee>> GetEmployees()
        //{
        //    return await context.Employees.ToListAsync();

        //}
        public async Task<List<EmployeeDto>> GetEmployees()
        {
            var employees = await context.Employees.ToListAsync();
            return employees.Select(emp => new EmployeeDto
            {
                Id = emp.Id,
                Name = emp.Name,
                Salary = emp.Salary,
                DateOfBirth = emp.DateOfBirth.ToString("yyyy-MM-dd"), // Format the date
                Gender = emp.Gender
            }).ToList();
        }

        public async Task SaveEmployee(Employee emp)
        {
            await context.Employees.AddAsync(emp);
            await context.SaveChangesAsync();
        }


        public async Task UpdateEmployee(int id, EmployeeUpdateDto updateDto)
        {
            var employee = await context.Employees.FindAsync(id);

            if (employee == null)
            {
                throw new Exception("Employee Not Found");
            }

            employee.Name = updateDto.Name;
            employee.Salary = updateDto.Salary;
            employee.DateOfBirth = updateDto.DateOfBirth;
            employee.Gender = updateDto.Gender;

            await context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if(employee == null)
            {
                throw new Exception("Employee not found");
            }
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
        }
    }
}
