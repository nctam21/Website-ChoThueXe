using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBookingCar.Models
{
    public class CommonAbstract
    {
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifierBy { get; set; }
        public string Fromdate { get; set; }
        public string Todate { get; set; }
    }
}