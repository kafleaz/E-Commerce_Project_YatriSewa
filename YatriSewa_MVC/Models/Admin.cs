using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YatriSewa_MVC.Models
{
    public class Bus
    {
        [Key]
        public int BusId { get; set; }

        [Required(ErrorMessage = "Bus Name is required")]
        [StringLength(255, ErrorMessage = "Bus Name cannot exceed 255 characters")]
        [Column("bus_name")]
        public string BusName { get; set; }

        [Required(ErrorMessage = "Bus Number is required")]
        [StringLength(100, ErrorMessage = "Bus Number cannot exceed 100 characters")]
        [Column("bus_no")]
        public string BusNumber { get; set; }

        [Required(ErrorMessage = "Starting location is required")]
        [StringLength(255, ErrorMessage = "Starting location cannot exceed 255 characters")]
        [Column("from_location")]
        public string From { get; set; }

        [Required(ErrorMessage = "Destination is required")]
        [StringLength(255, ErrorMessage = "Destination cannot exceed 255 characters")]
        [Column("to_location")]
        public string To { get; set; }

        [Required(ErrorMessage = "Seat Capacity is required")]
        [Column("seat_capacity")]
        public int SeatCapacity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Column("price")]
        public int Price { get; set; }

        [StringLength(255, ErrorMessage = "Photo path cannot exceed 255 characters")]
        [Column("photo_path")]
        public string PhotoPath { get; set; }
        //public IFormFile Photo { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        [Column("description")]
        public string Description { get; set; }

        public virtual Service Service { get; set; }
        public int OperatorId { get; set; }
        public virtual Operator Operator { get; set; }
    }
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "Wifi status is required")]
        [Column("wifi")]
        public bool Wifi { get; set; }

        [Required(ErrorMessage = "AC status is required")]
        [Column("ac")]
        public bool AC { get; set; }

        [Required(ErrorMessage = "Dinner/Lunch status is required")]
        [Column("dinner_lunch")]
        public bool Meals { get; set; }

        [StringLength(255, ErrorMessage = "Safety Features cannot exceed 255 characters")]
        [Column("safety_features")]
        public string SafetyFeatures { get; set; }

        [StringLength(255, ErrorMessage = "Essentials cannot exceed 255 characters")]
        [Column("essentials")]
        public string Essentials { get; set; }

        [StringLength(255, ErrorMessage = "Snacks cannot exceed 255 characters")]
        [Column("snacks")]
        public string Snacks { get; set; }

        [ForeignKey("Bus")]
        public int BusId { get; set; }
        public virtual Bus Bus { get; set; }
    }

    public class Operator
    {
        [Key]
        public int OperatorId { get; set; }

        [Required(ErrorMessage = "Operator Name is required")]
        [StringLength(255, ErrorMessage = "Operator Name cannot exceed 255 characters")]
        [Column("operator_name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(500, ErrorMessage = "Address cannot exceed 500 characters")]
        [Column("address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Contact Number is required")]
        [StringLength(20, ErrorMessage = "Contact Number cannot exceed 20 characters")]
        [Column("contact_no")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "License Number is required")]
        [StringLength(100, ErrorMessage = "License Number cannot exceed 100 characters")]
        [Column("license_no")]
        public string LicenseNo { get; set; }

        [Required(ErrorMessage = "Issue Date is required")]
        [Column("issue_date")]
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; }

        [Required(ErrorMessage = "Expiry Date is required")]
        [Column("expiry_date")]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
        public virtual ICollection<Bus> Buses { get; set; } = new List<Bus>();
    }

    public class BusFormViewModel
    {
        // Bus properties
        [Required]
        public string BusName { get; set; }
        [Required]
        public string BusNumber { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        [Required]
        public int SeatCapacity { get; set; }
        [Required]
        public int Price { get; set; }
        public IFormFile Photo { get; set; }
        [Required]
        public string Description { get; set; }

        // Service properties
        [Required]
        public bool WiFi { get; set; }
        [Required]
        public bool AC { get; set; }
        [Required]
        public bool Meals { get; set; }
        public string? SafetyFeatures { get; set; }
        public string? Essentials { get; set; }
        public string? Snacks { get; set; }

        // Operator properties
        [Required]
        public string OperatorName { get; set; }
        [Required]
        public string OperatorContact { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string LicenseNo { get; set; }
        [Required]
        public DateTime IssueDate { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
    }


    public class LoginAsOperator
    {
        [Required]
        public string OperatorEmail { get; set; }

        [Required]
        public string OperatorPassword { get; set; }
    }
}
