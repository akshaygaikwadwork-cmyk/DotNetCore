using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoginFormWithDatabaseFirstWithSession.Models
{
    public partial class TblEmployee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; } = null!;
        public string EmpGender { get; set; } = null!;
        public decimal EmpSalary { get; set; }
        public int EmpAge { get; set; }
        [Required(ErrorMessage ="Please enter emailId")]
        [DataType(DataType.EmailAddress)]
        public string? EmailId { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Please enter confirm password")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
