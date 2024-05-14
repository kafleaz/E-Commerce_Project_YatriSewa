using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YatriSewa_MVC.Models
{
    public class Bus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("bus_ID")]
        public int BusId { get; set; }

        [Column("bus_number")]
        public int BusNumber { get; set; }

        [Column("bus_status")]
        [StringLength(255)]
        public required string BusStatus { get; set; }

        [Column("bus_seats")]
        public int NumberOfSeats { get; set; }

        [ForeignKey("Driver")]
        [Column("driver_ID")]
        public int DriverId { get; set; }

        public virtual Driver Driver { get; set; }
    }
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("driver_ID")]
        public int DriverId { get; set; }

        [Column("name")]
        [StringLength(255)]
        public required string Name { get; set; }

        //[ForeignKey("Bus")]
        [Column("bus_ID")]
        public int BusId { get; set; }

        public virtual Bus Bus { get; set; }
    }
}
