namespace WebBookingCar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_CarCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_CarCategory()
        {
            tb_Car = new HashSet<tb_Car>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        public string Alias { get; set; }

        public string Description { get; set; }

        [StringLength(150)]
        public string Icon { get; set; }

        public string SeoTitle { get; set; }

        public string SeoDescription { get; set; }

        public string SeoKeywords { get; set; }

        public string CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifierBy { get; set; }

        public string Fromdate { get; set; }

        public string Todate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Car> tb_Car { get; set; }
    }
}
