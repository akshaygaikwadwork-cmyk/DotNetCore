using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstApproch_CRUDPractice.Model
{
    public class EmployeeModel
    {
        [Key]
        public int EmpId { get; set; }

        [Column(name:"EmpName",TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(50,ErrorMessage = "Name should be between 3 and 30 characters", MinimumLength = 3)]
        public string EmpName { get; set; }

        [Column(name: "EmpGender", TypeName = "varchar(20)")]
        [Required(ErrorMessage = "Please select gender")]
        public string Gender { get; set; }
        //public Gender? Gender { get; set; }

        [Column(name: "EmpSalary", TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "Please enter salary")]
        public decimal? EmpSalary { get; set; }

        [Column(name: "EmpAge", TypeName = "int")]
        [Required(ErrorMessage = "Please enter age")]
        [Range(20,60,ErrorMessage = "Age should be between 20 to 60")]
        public int? EmpAge { get; set; } 
    }

    //public enum Gender
    //{
    //    Male, Female
    //}


}
