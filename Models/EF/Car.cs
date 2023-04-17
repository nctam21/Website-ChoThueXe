using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBookingCar.Models.EF
{
    [Table("tb_Car")]
    public class Car : CommonAbstract
    {
        public Car()
        {
            this.CarImage = new HashSet<CarImage>();
            this.BookingDetails = new HashSet<BookingDetail>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        public string Image { get; set; }

        public decimal Price { get; set; }
        public decimal? PriceSale { get; set; }
        public bool IsSale { get; set; }
        public int Quantity { get; set; }
        public bool IsHome { get; set; }
        public int CarCategoryID { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public bool IsActive { get; set; }
        public virtual CarCategory CarCategory { get; set; }
        public virtual ICollection<CarImage> CarImage { get; set; }
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    }
}