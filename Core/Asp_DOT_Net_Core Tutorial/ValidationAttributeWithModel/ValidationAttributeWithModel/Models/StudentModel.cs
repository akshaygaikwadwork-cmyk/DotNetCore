using System.ComponentModel.DataAnnotations;

namespace ValidationAttributeWithModel.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter name")]
        [StringLength(15,MinimumLength = 3,ErrorMessage = "Name length must be between 3 to 15")]
        //OR
        //[MaxLength(15,ErrorMessage ="Name letter cannot be more than 15")]
        //[MinLength(3, ErrorMessage = "Name letter cannot be less than 3")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        //[EmailAddress]  // here we not using this annotation because it is not checking the .com validation so we are adding regular expression
        [RegularExpression("^[\\w.%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter Age")]
        [Range(10, 15,ErrorMessage =" Age must be between 10 to 15")]
        public int? Age { get; set; }  //here we used ? it accept null values this is used because validation coming when required put - [The value '' is invalid.]

        [Required(ErrorMessage = "Please enter Password")]
        [RegularExpression("(?=^.{8,}$)((?=.*\\d)|(?=.*\\W+))(?![.\\n])(?=.*[A-Z])(?=.*[a-z]).*$",ErrorMessage = "Uppercase, Lowercase, Numbers, Symbols, Minimun 8 letters")] 
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter Confirm Password")]
        [Compare("Password",ErrorMessage ="Confirm password and Password must be match")]
        [Display(Name = "Enter Confirm Password")]
        public string ConfirmPassword { get; set; }



        //@ - verbatim string literal
        // here we not used @ at starting to show this normal string or this raw string there is not excape sequence 
        // because in .net core 6 we not need to used @ but need to used in older version and in mvc 5 and older...

        [Required(ErrorMessage = "Please enter Mobile Number")]
        [RegularExpression("^[789]\\d{9}$", ErrorMessage = "Mobile number must be 10 digit and only start with 7,8,or 9")]
        //[RegularExpression("^\\d{10}$", ErrorMessage = "Mobile number must be 10 digit")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Please enter Website URL")]
        [Url(ErrorMessage ="Invalid URL")]
        public string WebsiteURL { get; set; }
    }


}

//Note - System.ComponentModel.DataAnnotations;