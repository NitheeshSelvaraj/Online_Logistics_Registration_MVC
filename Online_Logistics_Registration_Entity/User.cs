using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Logistics_Registration_Entity
{
        //public enum Gender
        //{
        //    Male,
        //    Female
        //}
        //public enum LorryType
        //{
        //    three_axeles_rigid,
        //    four_axeles_artic
        //}
        public class User
        {
              [Display(Name="Name")]
              [Required(ErrorMessage = "Name Required")]
              [MaxLength (20,ErrorMessage ="Name should contain only 20 characters")]
              [RegularExpression("^[A-Z][a-z]*$", ErrorMessage ="Name should start with capital letter")]
              public string name { get; set; }

              [Display(Name = "Mobile Number")]
              [Required (ErrorMessage ="Mobile Number Required")]
              [DataType(DataType.PhoneNumber)]
              [MaxLength(10, ErrorMessage = "Mobilenumber should contain only 10 characters")]
              [RegularExpression("^[6-9][0-9]{9}$", ErrorMessage = "Enter valid mobile number")]
              public string mobileNumber { get; set; }
        //public Gender gender;
        //public LorryType lorryType;

              [Display(Name = "User Name")]
              [Required(ErrorMessage = "UserName Required")]
              [MaxLength(7, ErrorMessage = "UserName should contain only 7 characters")]
              [RegularExpression("([a-z]|[a-z]{2}|[a-z]{3}|[a-z]{4}|[a-z]{5})[0-9]{2}$", ErrorMessage = "UserName should have 5 Letters and 2 digits")]
              public string userName { get; set; }

              [Display(Name = "Password")]
              [Required(ErrorMessage = "Password Required")]
              [RegularExpression("[a-z]*[@][0-9]*$", ErrorMessage = "Password should have Letters, digits and '@' in between them")]
              [MaxLength(20, ErrorMessage = "Password should contain only 20 characters")]
              public string password { get; set; }

              [Display(Name = "Confirm Password")]
              [Required(ErrorMessage = "Confirm Password Required")]
              [Compare("password",ErrorMessage ="Enter the matching password")]
              public string confirmPassword { get; set; }
    }
}
