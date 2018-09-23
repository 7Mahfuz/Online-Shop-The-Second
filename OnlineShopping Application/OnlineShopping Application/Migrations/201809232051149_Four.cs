namespace OnlineShopping_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Four : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DeliveryAddress", c => c.String());
            AddColumn("dbo.Products", "ImageUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ImageUrl");
            DropColumn("dbo.Products", "ImageUrl");
            DropColumn("dbo.Orders", "DeliveryAddress");
        }
    }
}
