namespace Roldaice.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserCustomization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCustomization",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IdenticonSeed = c.String(maxLength: 100),
                        NavbarBackgroundColor = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCustomization", "Id", "dbo.User");
            DropIndex("dbo.UserCustomization", new[] { "Id" });
            DropTable("dbo.UserCustomization");
        }
    }
}
