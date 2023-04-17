using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBookingCar.Models.EF
{
    [Table("tb_BookingDetail")]
    public class BookingDetail
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int CarId { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Car Car { get; set; }
    }
}