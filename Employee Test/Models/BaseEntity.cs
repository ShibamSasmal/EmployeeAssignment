using System.ComponentModel.DataAnnotations;

namespace Employee_Test.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
