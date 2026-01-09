using e_commerce_ModelClass.CustomValidator;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace e_commerce_ModelClass.Models
{
    public class Order
    {
        //[BindNever]
        //public int OrderNo { get; set; } // System-generated

        //[Required]
        //[DataType(DataType.DateTime)]
        //[CustomValidation(typeof(OrderValidator), nameof(OrderValidator.ValidateOrderDate))]
        //public DateTime OrderDate { get; set; }

        //[Required]
        //[Range(0.01, double.MaxValue, ErrorMessage = "InvoicePrice must be greater than zero.")]
        //public decimal InvoicePrice { get; set; }

        //[Required]
        //[MinLength(1, ErrorMessage = "At least one product is required.")]
        //public List<Product> Products { get; set; }

        //Udemy-

        [Display(Name = "Order Number")]
        public int? OrderNo { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Display(Name = "Order Date")]
        [MinimumDateValidator("2000-01-01", ErrorMessage = "Order Date should be greater than or equal to 2000")] //custom validator
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Display(Name = "Invoice Price")]
        [InvoicePriceValidator] //custom validator
        [Range(1, double.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        public double InvoicePrice { get; set; }

        [ProductsListValidator] //custom validator
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
