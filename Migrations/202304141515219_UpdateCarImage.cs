namespace WebBookingCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCarImage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_CarImage", "Car_Id", "dbo.tb_Car");
            DropIndex("dbo.tb_CarImage", new[] { "Car_Id" });
            RenameColumn(table: "dbo.tb_CarImage", name: "Car_Id", newName: "CarId");
            AlterColumn("dbo.tb_CarImage", "CarId", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_CarImage", "CarId");
            AddForeignKey("dbo.tb_CarImage", "CarId", "dbo.tb_Car", "Id", cascadeDelete: true);
            DropColumn("dbo.tb_CarImage", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_CarImage", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.tb_CarImage", "CarId", "dbo.tb_Car");
            DropIndex("dbo.tb_CarImage", new[] { "CarId" });
            AlterColumn("dbo.tb_CarImage", "CarId", c => c.Int());
            RenameColumn(table: "dbo.tb_CarImage", name: "CarId", newName: "Car_Id");
            CreateIndex("dbo.tb_CarImage", "Car_Id");
            AddForeignKey("dbo.tb_CarImage", "Car_Id", "dbo.tb_Car", "Id");
        }
    }
}
