
using System.ComponentModel.DataAnnotations;


namespace Online_Logistics_Registration.Models
{
    public class User
    {
        //[Display(Name = "UserId")]
        //[Required(ErrorMessage = "Id Required")]
        //[Range(1000, 9999)]
        //public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name Required")]
        [MaxLength(30, ErrorMessage = "Name should contain only 20 characters")]
        [RegularExpression("^[A-Z][a-z]*$", ErrorMessage = "Name should start with capital letter")]
        public string Name { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Mobile Number Required")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(10, ErrorMessage = "Mobilenumber should contain only 10 characters")]
        [RegularExpression("^[6-9][0-9]{9}$", ErrorMessage = "Enter valid mobile number")]
        public string MobileNumber { get; set; }
        //public Gender gender;
        //public LorryType lorryType;
        [Display(Name = "Email Id")]
        [Required(ErrorMessage = "Email Id Required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("[a-z]+[.0-9a-z]*[@][a-z]+.[a-z]+$", ErrorMessage = "Enter valid Email address")]
        public string Email { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "UserName Required")]
        [MaxLength(7, ErrorMessage = "UserName should contain only 7 characters")]
        [RegularExpression("([a-z]|[a-z]{2}|[a-z]{3}|[a-z]{4}|[a-z]{5})[0-9]{2}$", ErrorMessage = "UserName should have 5 Letters and 2 digits")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Required")]
        [RegularExpression("[a-z]*[@][0-9]*$", ErrorMessage = "Password should have Letters, digits and '@' in between them")]
        [MaxLength(20, ErrorMessage = "Password should contain only 20 characters")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password Required")]
        [Compare("Password", ErrorMessage = "Enter the matching password")]
        public string ConfirmPassword { get; set; }
    }
}