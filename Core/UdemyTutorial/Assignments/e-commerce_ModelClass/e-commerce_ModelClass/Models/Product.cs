using System.ComponentModel.DataAnnotations;

namespace e_commerce_ModelClass.Models
{
    public class Product
    {
        //[Required]
        //public int ProductCode { get; set; }

        //[Required]
        //[Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        //public decimal Price { get; set; }

        //[Required]
        //[Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        //public int Quantity { get; set; }

        //Udemy-

        [Required(ErrorMessage = "{0} can't be blank")]
        [Display(Name = "Product Code")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        public int ProductCode { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Display(Name = "Product Price")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        public double Price { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Display(Name = "Product Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        public int Quantity { get; set; }
    }
}
