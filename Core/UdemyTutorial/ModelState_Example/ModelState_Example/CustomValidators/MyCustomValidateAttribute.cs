using System.ComponentModel.DataAnnotations;

namespace ModelState_Example.CustomValidators
{
    public class MyCustomValidateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year >= DateTime.Today.Year)
                {
                    return new ValidationResult(validationContext.MemberName + " cannot be current or future date.");
                    //OR
                    //if tou want to show our customErrorMessage then you use like below-
                    //return new ValidationResult( ErrorMessage );
                }
                return ValidationResult.Success;
            }
            return null;
        }
    }
}
