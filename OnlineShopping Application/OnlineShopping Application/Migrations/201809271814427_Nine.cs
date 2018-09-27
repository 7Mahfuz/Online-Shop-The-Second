namespace OnlineShopping_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nine : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "TrxNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "TrxNo");
        }
    }
}
