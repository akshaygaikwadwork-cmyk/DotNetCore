using System.ComponentModel.DataAnnotations;

namespace CRUDAppUsingAspCoreWebAPI.Models
{
    public class Student
    {
        [Display(Name = "Id")]
        public int id { get; set; }

        [Required(ErrorMessage ="please enter name")]
        [Display(Name = "Name")]
        public string studName { get; set; }

        [Required(ErrorMessage = "please enter gender")]
        [Display(Name = "Gender")]
        public string studGender { get; set; }

        [Required(ErrorMessage = "please enter age")]
        [Display(Name = "Age")]
        public int? studAge { get; set; }

        [Required(ErrorMessage = "please enter standard")]
        [Display(Name = "Standard")]
        public int? studStandard { get; set; }
    }
}
