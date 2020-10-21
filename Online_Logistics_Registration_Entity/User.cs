
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
              //[Display(Name="Id")]
              //[Required(ErrorMessage ="Id Required")]
              //[Range(1000,9999)]
              [Key]
              [Column("UserId",Order =0)]
              [Required]
              public int Id { get; set; }     

              //[Display(Name="Name")]
              //[Required(ErrorMessage = "Name Required")]
              //[MaxLength (20,ErrorMessage ="Name should contain only 20 characters")]
              //[RegularExpression("^[A-Z][a-z]*$", ErrorMessage ="Name should start with capital letter")]
              [Required]
              [Column(Order =1)]
              public string Name { get; set; }

        //[Display(Name = "Mobile Number")]
        //[Required (ErrorMessage ="Mobile Number Required")]
        //[DataType(DataType.PhoneNumber)]
        //[MaxLength(10, ErrorMessage = "Mobilenumber should contain only 10 characters")]
        //[RegularExpression("^[6-9][0-9]{9}$", ErrorMessage = "Enter valid mobile number")]
        [Required]
        [Column(Order =2)]
        [MaxLength(10)]
        [Index(IsUnique = true)]
        public string MobileNumber { get; set; }
       
        //public Gender gender;
        //public LorryType lorryType;
        [Required]
        [Column(Order =3)]
        [MaxLength(300)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        //[Display(Name = "User Name")]
        //[Required(ErrorMessage = "UserName Required")]
        //[MaxLength(7, ErrorMessage = "UserName should contain only 7 characters")]
        //[RegularExpression("([a-z]|[a-z]{2}|[a-z]{3}|[a-z]{4}|[a-z]{5})[0-9]{2}$", ErrorMessage = "UserName should have 5 Letters and 2 digits")]
        [Required]
        [Column(Order =4)]
        [MaxLength(7)]
        [Index(IsUnique = true)]
        public string UserName { get; set; }

        //[Display(Name = "Password")]
        //[Required(ErrorMessage = "Password Required")]
        //[RegularExpression("[a-z]*[@][0-9]*$", ErrorMessage = "Password should have Letters, digits and '@' in between them")]
        //[MaxLength(20, ErrorMessage = "Password should contain only 20 characters")]
        [Required]
        [Column(Order =5)]
        public string Password { get; set; }

        //[Display(Name = "Confirm Password")]
        //[Required(ErrorMessage = "Confirm Password Required")]
        //[Compare("password",ErrorMessage ="Enter the matching password")]
        // public string ConfirmPassword { get; set; }
        [Required]
        [Column(Order =6)]
        public string Role { get; set; }
        public User()
        {
            this.Role = "User";
        }
        //{
        //    get { return Role; }
        //    set { Role = "User"; }
        //}
        [Column("Points", Order = 7)]
        public int Points { get; set; }
    }
}
