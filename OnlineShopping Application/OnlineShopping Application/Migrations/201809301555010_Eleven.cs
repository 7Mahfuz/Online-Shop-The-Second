namespace OnlineShopping_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eleven : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Subject = c.String(),
                        Detail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Payments", "CashOnDelivery", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "CashOnDelivery");
            DropTable("dbo.FeedBacks");
        }
    }
}
