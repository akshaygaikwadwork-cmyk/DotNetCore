using ModelState_Example.CustomValidators;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelState_Example.Models
{
    public class Person : IValidatableObject
    {
        [Required(ErrorMessage = "{0} cannot be null or empty.")]
        [DisplayName("User Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} length should be between {2} and {1}")]
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Salary { get; set; }
        public string? Designation { get; set; }
        public string? Address { get; set; }

        [MyCustomValidateAttribute]
        public DateTime? DOB { get; set; }
        public DateTime? FromDate { get; set; }

        [DateRangeValidator("FromDate",ErrorMessage = "'From Date' should be older than or equal to 'To Date'")]
        public DateTime? ToDate { get; set; }

        //It will call when all error message or validation are clear like DOB pttern or name range etc...
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DOB.HasValue == false && Age.HasValue == false)
            {
                yield return new ValidationResult("Either of Date of Birth or Age must be supplied", new[] { nameof(Age) });
            }
        }
    }
}
