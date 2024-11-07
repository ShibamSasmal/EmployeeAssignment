using Employee_Test.Data;
using Employee_Test.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Employee_Test.Repository
{
    public class DepartmentRepository 
    {
        private readonly AppDbContext context;

        public DepartmentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Department>> GetDepartments()
        {
            return await context.Departments.ToListAsync();
        }
        public async Task SaveDepartments(Department department)
        {
            await context.Departments.AddAsync(department);
            await context.SaveChangesAsync();
        }

        public async Task UpdateDepartment(int id, Department dept)
        {
            var data = await context.Departments.FindAsync(id);
            if(data == null)
            {
                throw new Exception("Department not found");
            }
            data.Name = dept.Name;
            await context.SaveChangesAsync();

        }

        public async Task DeleteDepartment(int id)
        {
            var data =  await context.Departments.FindAsync(id);
            if(data == null)
            {
                throw new Exception("No Departments Found");
            }
            context.Departments.Remove(data);
            await context.SaveChangesAsync();
        }

    }
}
