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
        public int? UserId { get; set; }
    }

    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual Customer Customer { get; set; }

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
        [StringLength(10)]
        public string SeatNumber { get; set; }
    }

}
