using System.ComponentModel.DataAnnotations;

namespace Employee_Test.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        //public ICollection<EmployeeDepartmentMapping> EmployeeDepartments { get; set; }
    }
}
