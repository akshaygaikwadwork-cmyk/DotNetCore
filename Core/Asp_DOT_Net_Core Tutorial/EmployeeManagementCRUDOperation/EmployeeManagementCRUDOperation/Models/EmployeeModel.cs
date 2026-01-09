using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementCRUDOperation.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string? FName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string? LName { get; set; }

        [Required(ErrorMessage = "Please enter email id")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter mobile number")]
        [Display(Name = "Mobile number")]
        public long Mobile { get; set; }

        [Required(ErrorMessage = "Please enter Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date Of Birth")]
        public DateTime? DOB { get; set; }
        [Required(ErrorMessage = "Please enter age")]
        [Display(Name ="Age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please select gender")]
        [Display(Name ="Gender")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Please select department")]
        [Display(Name = "Department")]
        public string? Department { get; set; }

        [Required(ErrorMessage = "Please enter salary")]
        [Display(Name = "Salary")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Please enter address")]
        [Display(Name = "Address")]
        public string? Address { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? is_deleted { get; set; } = 0;

    }

    public class Department
    {
        [Key]
        public int D_Id { get; set; }
        public string Department_name { get; set; }
    }
}
