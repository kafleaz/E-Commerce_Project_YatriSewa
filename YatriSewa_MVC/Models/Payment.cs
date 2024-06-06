using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace YatriSewa_MVC.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int PassengerId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal AmountPaid { get; set; }
        public string PaymentMethod { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiry { get; set; }
        public string TransactionId { get; set; }
        public string Status { get; set; }

        // Navigation property
        public Passenger Passenger { get; set; }
    }

    //public class TransactionReport
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    [Column("report_ID")]
    //    public int ReportId { get; set; }

    //    [ForeignKey("Customer")]
    //    [Column("customer_ID")]
    //    public int CustomerId { get; set; }

    //    public virtual Customer Customer { get; set; }

    //    //[ForeignKey("Reservation")]
    //    //[Column("reservation_ID")]
    //    //[Required]
    //    //public int ReservationId { get; set; }

    //    //public virtual Reservation Reservation { get; set; }

    //    //[ForeignKey("Payment")]
    //    //[Column("payment_ID")]
    //    //public int PaymentId { get; set; }

    //    public virtual Payment Payment { get; set; }

    //    [Column("report_date")]
    //    public DateTime ReportDate { get; set; }
    //}
}
