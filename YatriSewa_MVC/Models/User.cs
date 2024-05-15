using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YatriSewa_MVC.Models
{
    public class LoginUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("login_Id")]
        public int Login_ID { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be 6 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        ////[ForeignKey("Customer")]
        //[Column("customer_ID")]
        //public virtual Customer Customer { get; set; }
    }

    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("customer_ID")]
        public int CustomerId { get; set; }

        // Foreign key to link Customer with ApplicationUser (IdentityUser)
        [ForeignKey("LoginUser")]
        [Column("login_ID")]
        public int Login_ID { get; set; }

        public virtual LoginUser LoginUser { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(255, ErrorMessage = "First Name cannot exceed 255 characters")]
        [Column("fname")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(255, ErrorMessage = "Last Name cannot exceed 255 characters")]
        [Column("lname")]
        public string LastName { get; set; }

        [Column("gender")]
        public string Gender { get; set; }

        [Column("age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Contact Number is required")]
        //[RegularExpression(@"^9\d{9}$", ErrorMessage = "Invalid contact number.")]
        [StringLength(10, ErrorMessage = "Invalid contact number.")]
        [Column("contact_no")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "District is required")]
        [StringLength(255, ErrorMessage = "District cannot exceed 255 characters")]
        [Column("district")]
        public string District { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(255, ErrorMessage = "City cannot exceed 255 characters")]
        [Column("city")]
        public string City { get; set; }
    }

    public class LogUser
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }


        [Compare("Password", ErrorMessage = "Invalid Password")]
        public string Password { get; set; }
    }

    public class ForgotPassword
    {
       
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "User does not Exists")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be 6 characters long")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }
    }

    
}
