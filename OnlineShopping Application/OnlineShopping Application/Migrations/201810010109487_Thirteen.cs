namespace OnlineShopping_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Thirteen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeedBacks", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FeedBacks", "Date");
        }
    }
}
