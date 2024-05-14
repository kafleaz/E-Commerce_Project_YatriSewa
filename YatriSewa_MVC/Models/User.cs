using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YatriSewa_MVC.Models
{
    //public class LoginUser
    //{
    //    [Key]
    //    [Column("LoginId")]
    //    public int LoginId { get; set; }

    //    [Required(ErrorMessage = "Email is required")]
    //    [EmailAddress(ErrorMessage = "Invalid email address")]
    //    public required string Email { get; set; }

    //    [Required(ErrorMessage = "Password is required")]
    //    [DataType(DataType.Password)]
    //    public required string Password { get; set; }

    //    [Required(ErrorMessage = "Password dosent match")]
    //    [DataType(DataType.Password)]
    //    public required string ConfirmPassword { get; set; }
    //}

    public class LoginUser
    {
        [Key]
        [Column("LoginId")]
        public int LoginId { get; set; }

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
    }

    //public class Customer
    //{
    //    [Key]
    //    [Column("customer_ID")]
    //    public int CustomerId { get; set; }

    //    [ForeignKey("ApplicationUser")]
    //    public string UserId { get; set; }
    //    public virtual ApplicationUser User { get; set; }

    //    [ForeignKey("Login")]
    //    [Column("login_ID")]
    //    public int LoginId { get; set; } 
    //    public virtual LoginUser LoginUser { get; set; }

    //    [Required(ErrorMessage = "First Name is required")]
    //    [StringLength(255, ErrorMessage = "First Name cannot exceed 255 characters")]
    //    [Column("fname")]
    //    public required string FirstName { get; set; }

    //    [Required(ErrorMessage = "Last Name is required")]
    //    [StringLength(255, ErrorMessage = "Last Name cannot exceed 255 characters")]
    //    [Column("lname")]
    //    public required string LastName { get; set; }

    //    [Column("gender")]
    //    public int Gender { get; set; }

    //    [Column("age")]
    //    public int Age { get; set; }

    //    [Required(ErrorMessage = "Contact Address is required")]
    //    [StringLength(255, ErrorMessage = "Contact Address cannot exceed 255 characters")]
    //    [Column("contact_add")]
    //    public required int ContactNo { get; set; }
    //}

    public class Customer
    {
        [Key]
        [Column("customer_ID")]
        public int CustomerId { get; set; }

        // Foreign key to link Customer with ApplicationUser (IdentityUser)
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(255, ErrorMessage = "First Name cannot exceed 255 characters")]
        [Column("fname")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(255, ErrorMessage = "Last Name cannot exceed 255 characters")]
        [Column("lname")]
        public string LastName { get; set; }

        [Column("gender")]
        public int Gender { get; set; }

        [Column("age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Contact Address is required")]
        [StringLength(255, ErrorMessage = "Contact Address cannot exceed 255 characters")]
        [Column("contact_add")]
        public string ContactNo { get; set; }
    } 
}
