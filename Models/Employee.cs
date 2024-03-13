using System.ComponentModel.DataAnnotations;

namespace MVC_CORE_tu.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
