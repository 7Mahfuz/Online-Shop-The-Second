namespace OnlineShopping_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Twelve : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Payments", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "Date");
            DropColumn("dbo.Orders", "Date");
        }
    }
}
