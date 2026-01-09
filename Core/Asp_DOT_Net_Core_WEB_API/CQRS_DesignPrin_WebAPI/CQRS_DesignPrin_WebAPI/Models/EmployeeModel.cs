using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRS_DesignPrin_WebAPI.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "Varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar(300)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "Varchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "Varchar(10)")]
        public string Phone { get; set; }
    }
}
