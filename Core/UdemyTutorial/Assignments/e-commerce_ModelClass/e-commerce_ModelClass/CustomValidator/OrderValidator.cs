using System.ComponentModel.DataAnnotations;

namespace e_commerce_ModelClass.CustomValidator
{
    public class OrderValidator
    {
        public static ValidationResult ValidateOrderDate(DateTime orderDate, ValidationContext context)
        {
            if (orderDate < new DateTime(2000, 1, 1))
            {
                return new ValidationResult("OrderDate can't be blank");
            }
            return ValidationResult.Success;
        }
    }
}
