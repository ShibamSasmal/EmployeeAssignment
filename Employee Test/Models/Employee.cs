using System.ComponentModel.DataAnnotations;

namespace Employee_Test.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        
    }
}
