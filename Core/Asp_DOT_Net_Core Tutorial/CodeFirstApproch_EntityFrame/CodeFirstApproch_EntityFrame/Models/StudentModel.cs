using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstApproch_EntityFrame.Models
{
    public class StudentModel
    {
        [Key] //used for primary key 
        public int Id { get; set; }

        [Column("StudName",TypeName = "varchar(100)")]
        [Required(ErrorMessage ="Please enter Name")]
        public string Name { get; set; }

        [Column("StudGender", TypeName = "varchar(20)")]
        [Required(ErrorMessage = "Please enter Gender")]
        public string Gender { get; set; }

        [Column("StudAge", TypeName = "int")]
        [Required(ErrorMessage = "Please enter Age")]
        public int? Age { get; set; }

        [Column("StudStandard", TypeName = "int")]
        [Required(ErrorMessage = "Please enter Standard")]
        public int? Standard { get; set; }
    }
}
