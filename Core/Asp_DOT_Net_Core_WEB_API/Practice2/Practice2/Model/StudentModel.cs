using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice2.Model
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Age { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Address { get; set; }
    }
}
