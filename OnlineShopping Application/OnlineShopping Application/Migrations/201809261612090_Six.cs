namespace OnlineShopping_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Six : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carts", "Quantity", c => c.Double(nullable: false));
            AlterColumn("dbo.CartToDelivers", "Quantity", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CartToDelivers", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Carts", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
