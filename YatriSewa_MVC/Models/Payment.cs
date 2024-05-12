using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YatriSewa_MVC.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("payment_ID")]
        public int PaymentId { get; set; }

        [ForeignKey("Customer")]
        [Column("customer_ID")]
        public int CustomerId { get; set; }

        public virtual required Customer Customer { get; set; }

        //[ForeignKey("Reservation")]
        [Column("reservation_ID")]
        public int ReservationId { get; set; }

        public virtual required Reservation Reservation { get; set; }

        [Column("payment_date")]
        public DateTime PaymentDate { get; set; }
    }

    public class TransactionReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("report_ID")]
        public int ReportId { get; set; }

        [ForeignKey("Customer")]
        [Column("customer_ID")]
        public int CustomerId { get; set; }

        public virtual required Customer Customer { get; set; }

        [ForeignKey("Reservation")]
        [Column("reservation_ID")]
        public int ReservationId { get; set; }

        public virtual required Reservation Reservation { get; set; }

        [ForeignKey("Payment")]
        [Column("payment_ID")]
        public int PaymentId { get; set; }

        public virtual required Payment Payment { get; set; }

        [Column("report_date")]
        public DateTime ReportDate { get; set; }
    }
}
