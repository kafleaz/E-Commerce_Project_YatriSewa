using System.ComponentModel.DataAnnotations;

namespace YatriSewa_MVC.Models
{
    public class Seat
    {
        public int SeatId { get; set; }
        public int BusId { get; set; }
        public string SeatNumber { get; set; }
        public bool IsSold { get; set; }
        public bool IsReserved { get; set; }
        public string Status { get; set; }
        public int? UserId { get; set; }
        public virtual Passenger Passenger { get; set; }
    }

    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int BusId { get; set; }
        public virtual Bus Bus { get; set; }

        [Required(ErrorMessage = "Ticket Number is required")]
        [StringLength(100)]
        public string TicketNumber { get; set; }

        [Required(ErrorMessage = "PNR Number is required")]
        [StringLength(100)]
        public string PNRNumber { get; set; }

        [Required]
        public decimal AmountPaid { get; set; }

        [Required]
        public string SeatNumber { get; set; }
    }

    public class SeatSelectionViewModel
    {
        public int BusId { get; set; }
        public string BusName { get; set; }
        public int SeatCapacity { get; set; }
        public decimal Price { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal TotalAmount { get; set; }
        public string SeatNumber { get; set; }
        public List<SeatViewModel> Seats { get; set; }
    }

    public class SeatViewModel
    {
        public string SeatNumber { get; set; }
        public bool IsReserved { get; set; }
        public bool IsSold { get; set; }
        public bool IsSelected { get; set; }
    }


}
