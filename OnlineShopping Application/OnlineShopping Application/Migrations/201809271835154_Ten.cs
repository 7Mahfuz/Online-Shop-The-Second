namespace OnlineShopping_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ten : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartToDelivers", "PaymentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartToDelivers", "PaymentId");
        }
    }
}
