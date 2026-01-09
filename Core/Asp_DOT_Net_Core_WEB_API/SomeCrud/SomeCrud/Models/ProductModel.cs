using System.ComponentModel.DataAnnotations;

namespace SomeCrud.Models;

public class ProductModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(60)]
    public string? Name { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    // [MinLength(50)]
    [Range(50,100000)]
    public int? Stock { get; set; }
}