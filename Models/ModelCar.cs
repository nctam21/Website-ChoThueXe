using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebBookingCar.Models
{
    public partial class ModelCar : DbContext
    {
        public ModelCar()
            : base("name=ModelCar")
        {
        }

        public virtual DbSet<tb_Car> tb_Car { get; set; }
        public virtual DbSet<tb_CarCategory> tb_CarCategory { get; set; }
        public virtual DbSet<tb_CarImage> tb_CarImage { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tb_Car>()
                .HasMany(e => e.tb_CarImage)
                .WithRequired(e => e.tb_Car)
                .HasForeignKey(e => e.CarId);

            modelBuilder.Entity<tb_CarCategory>()
                .HasMany(e => e.tb_Car)
                .WithRequired(e => e.tb_CarCategory)
                .HasForeignKey(e => e.CarCategoryID);
        }
    }
}
