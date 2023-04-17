namespace WebBookingCar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCar1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Car", "IsSale", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Car", "IsSale");
        }
    }
}
