using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice1.Model
{
    public class StudentTemp
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName="varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "int")]
        public int Age { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string Address { get; set; }
    }
}
