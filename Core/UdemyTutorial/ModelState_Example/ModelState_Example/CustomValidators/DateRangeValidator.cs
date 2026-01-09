using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelState_Example.CustomValidators
{
    public class DateRangeValidator : ValidationAttribute
    {
        private readonly string OtherPropertyName;
        public DateRangeValidator(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                //Get to_date
                DateTime to_date  = (DateTime)value;
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);

                //Get from_date
                DateTime from_date  = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));

                if(from_date > to_date)
                {
                    //return new ValidationResult(ErrorMessage, new string[] {OtherPropertyName,validationContext.MemberName});
                    return new ValidationResult(ErrorMessage);
                }
                return ValidationResult.Success;
            }
            return null;
        }
    }
}
