﻿using System.ComponentModel.DataAnnotations;

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
        public int PassengerId { get; set; }
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
        public int PassengerId { get; set;}
        public List<SeatViewModel> Seats { get; set; }
    }

    public class SeatViewModel
    {
        public int UserId { get; set; }
        public string SeatNumber { get; set; }
        public bool IsReserved { get; set; }
        public bool IsSold { get; set; }
        public bool IsSelected { get; set; }
        public int BusId { get; set; }
    }

    public class ReserveSeatsModel
    {
        public int PassengerId { get; set; }
        public int BusId { get; set; }
        public int UserId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Date { get; set; }
        public string SeatNumbers { get; set; }
        public bool IsReserved { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class BuySeatsModel
    {
        public int PassengerId { get; set; }
        public int BusId { get; set; }
        public int UserId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Date { get; set; }
        public string SeatNumbers { get; set; }
        public bool IsSold { get; set; }
        public decimal TotalAmount { get; set; }
    }
    public class PaymentViewModel
    {
        public int BusId { get; set; }
        public string BusNumber { get; set; }
        public string BusName { get; set; }
        public string Time { get; set; }
        public int UserId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Date { get; set; }
        public decimal TotalAmount { get; set; }
        public string SeatNumbers { get; set; }
        public string PNRNumber { get; set; }
        public int PassengerId { get; set; }
        public string FullName { get; set; }
        public string TicketNumber { get; set; }
        public string StripeToken { get; set; }
       
        public decimal AmountPaid { get; set; }
   
        public string CardNumber { get; set; }
        
        public string CardExpiry => $"{ExpiryMonth:D2}/{ExpiryYear:D2}";
        public int ExpiryMonth { get; set; }
        public string CVC { get; set; }
        public int ExpiryYear { get; set; }
        public string StripePublishableKey { get; set; }
        public string CardCvc { get; set; }
    }
    //public class ProcessPaymentViewModel
    //{
    //    public int PassengerId { get; set; }
    //    public decimal AmountPaid { get; set; }
    //    public string CardNumber { get; set; }
    //    public int ExpiryMonth { get; set; }
    //    public int ExpiryYear { get; set; }
    //    public string CardCvc { get; set; }
    //}

}
