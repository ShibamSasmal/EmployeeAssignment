﻿using System.ComponentModel.DataAnnotations;

namespace Employee_Test.Models
{
    public class EmployeeDepartmentMapping
    {
        
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Employee Employee { get; set; }
        public Department Department { get; set; }
    }
}
