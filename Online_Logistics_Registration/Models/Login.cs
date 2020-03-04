using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Logistics_Registration.Models
{
    public class Login
    {
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
    }
}