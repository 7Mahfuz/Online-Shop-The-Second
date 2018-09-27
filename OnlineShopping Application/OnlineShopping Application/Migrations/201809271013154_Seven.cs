namespace OnlineShopping_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seven : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        ImagePath = c.String(),
                        Address = c.String(),
                        Number = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.AspNetUsers", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ImageUrl", c => c.String());
            DropTable("dbo.Users");
        }
    }
}
