namespace Roldaice.Dal.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            #region Schema
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Label = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 64),
                        Salt = c.String(nullable: false, maxLength: 100),
                        CreationDate = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "GETDATE()")
                                },
                            }),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.Login, unique: true)
                .Index(t => t.RoleId);
            #endregion Schema

            #region Data
            Sql("INSERT INTO [dbo].[Role] (Id, Label) VALUES (10, 'Administrateur')");
            Sql("INSERT INTO [dbo].[Role] (Id, Label) VALUES (20, 'Utilisateur')");
            Sql("INSERT INTO [dbo].[Role] (Id, Label) VALUES (30, 'Vistieur')");

            Sql("INSERT INTO [dbo].[User] (Login, Password, Salt, RoleId) VALUES ('root', '', '', 10)");
            #endregion Data
        }

        public override void Down()
        {
            DropForeignKey("dbo.User", "RoleId", "dbo.Role");
            DropIndex("dbo.User", new[] { "RoleId" });
            DropIndex("dbo.User", new[] { "Login" });
            DropTable("dbo.User",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreationDate",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "GETDATE()" },
                        }
                    },
                });
            DropTable("dbo.Role");
        }
    }
}
