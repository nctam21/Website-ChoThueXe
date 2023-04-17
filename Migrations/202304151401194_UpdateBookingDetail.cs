namespace WebBookingCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBookingDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_BookingDetail", "Booking_Id", "dbo.tb_Booking");
            DropIndex("dbo.tb_BookingDetail", new[] { "Booking_Id" });
            RenameColumn(table: "dbo.tb_BookingDetail", name: "Booking_Id", newName: "BookingId");
            AlterColumn("dbo.tb_BookingDetail", "BookingId", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_BookingDetail", "BookingId");
            AddForeignKey("dbo.tb_BookingDetail", "BookingId", "dbo.tb_Booking", "Id", cascadeDelete: true);
            DropColumn("dbo.tb_BookingDetail", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_BookingDetail", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.tb_BookingDetail", "BookingId", "dbo.tb_Booking");
            DropIndex("dbo.tb_BookingDetail", new[] { "BookingId" });
            AlterColumn("dbo.tb_BookingDetail", "BookingId", c => c.Int());
            RenameColumn(table: "dbo.tb_BookingDetail", name: "BookingId", newName: "Booking_Id");
            CreateIndex("dbo.tb_BookingDetail", "Booking_Id");
            AddForeignKey("dbo.tb_BookingDetail", "Booking_Id", "dbo.tb_Booking", "Id");
        }
    }
}
