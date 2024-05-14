using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YatriSewa_MVC.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("order_ID")]
        public int OrderId { get; set; }

        [ForeignKey("Customer")]
        [Column("customer_ID")]
        public int CustomerId { get; set; }

        public virtual  Customer Customer { get; set; }

        [Column("order_date")]
        public DateTime OrderDate { get; set; }
    }

    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("reservation_ID")]
        public int ReservationId { get; set; }

        [ForeignKey("Customer")]
        [Column("customer_ID")]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        [Column("bus_ID")]
        public int BusId { get; set; }

        [Column("departure_time")]
        public DateTime DepartureTime { get; set; }

        [Required(ErrorMessage = "Destination is required")]
        [StringLength(255)]
        public required string Destination { get; set; }

        [Column("reservation_date")]
        public DateTime ReservationDate { get; set; }
    }

}
