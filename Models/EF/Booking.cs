using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBookingCar.Models.EF
{
    [Table("tb_Booking")]
    public class Booking : CommonAbstract
    {
        public Booking()
        {
            this.BookingDetails = new HashSet<BookingDetail>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
    
        public string CustomerId { get; set; }

        public decimal TotalAmount { get; set; }
        public int Quantity { get; set; }
        public ICollection<BookingDetail> BookingDetails { get; set; }
        public int TypePayment { get; set; }
    }
}