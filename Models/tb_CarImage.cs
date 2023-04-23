namespace WebBookingCar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_CarImage
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public bool IsDefault { get; set; }

        public int CarId { get; set; }

        public virtual tb_Car tb_Car { get; set; }
    }
}
