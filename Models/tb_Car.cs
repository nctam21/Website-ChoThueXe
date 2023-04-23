namespace WebBookingCar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Car()
        {
            tb_CarImage = new HashSet<tb_CarImage>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        public string Alias { get; set; }

        public string Description { get; set; }

        public string Detail { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public bool IsHome { get; set; }

        public int CarCategoryID { get; set; }

        public string SeoTitle { get; set; }

        public string SeoDescription { get; set; }

        public string SeoKeywords { get; set; }

        public bool IsActive { get; set; }

        public string CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifierBy { get; set; }

        public string Fromdate { get; set; }

        public string Todate { get; set; }

        public decimal? PriceSale { get; set; }

        public bool IsSale { get; set; }

        public virtual tb_CarCategory tb_CarCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_CarImage> tb_CarImage { get; set; }
    }
}
