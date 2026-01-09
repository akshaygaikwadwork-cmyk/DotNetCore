using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Operation_JqueryAJAX.Models
{
    public class HotelModel
    {
        [Key]
        public int? CustomerId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage ="Please enter customer name")]
        public string? CustomerName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage ="Please enter dish name")]
        public string? DishName { get; set; }

        [Required(ErrorMessage = "Please enter quantity")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Please enter amount")]
        public int? Amount { get; set; }

        [Display(Name = "Dish Image")]
        [NotMapped]
        public IFormFile? DishImage { get; set; }

        [Display(Name = "Dish Image Name")]
        [Column(TypeName = "nvarchar(800)")]
        public string? DishImageName { get; set; }

        [Column(TypeName = "DateTime")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}")]
        public DateTime? OrderDate { get; set; }
        public int? Is_deleted { get; set; } = 0;

    }
}
