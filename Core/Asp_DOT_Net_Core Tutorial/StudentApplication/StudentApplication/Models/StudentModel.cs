using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApplication.Models
{
    public class StudentModel
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Please enter age")]
        public int Age { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }
    }
}
