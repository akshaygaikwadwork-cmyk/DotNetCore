using System.ComponentModel.DataAnnotations;

namespace First_WebApi.Models
{
    public class StudentRegModel
    {
        [Key]
        [Display(Name = "Student Id")]
        public int Id { get; set; }

        [MinLength(2),MaxLength(100)]
        [Display(Name="Student Name")]
        [Required(ErrorMessage ="Please enter Student Name")]
        public string? Name { get; set; }

        [Range(1,100)]
        [Display(Name = "Student Age")]
        [Required(ErrorMessage = "Please enter Student Age")]
        public int? Age { get; set; }

        [MinLength(2),MaxLength(500)]
        [Display(Name = "Student Address")]
        [Required(ErrorMessage = "Please enter Student Address")]
        public string? Address { get; set; }
    }
}
