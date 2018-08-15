namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyCommanders",
                c => new
                    {
                        CommanderId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Rank = c.String(),
                        SocialSecurityNumber = c.Int(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CommanderId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.FirstSergeants",
                c => new
                    {
                        FirstSergeantID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        SocialSecurityNumber = c.Int(),
                        Rank = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FirstSergeantID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Soldiers",
                c => new
                    {
                        SoldierId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Rank = c.String(),
                        SocialSecurityNumber = c.Int(),
                        LeaveForm = c.String(),
                        LES = c.String(),
                        UnitNumber = c.String(),
                        Division = c.String(),
                        Leadership = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SoldierId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Soldiers", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FirstSergeants", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CompanyCommanders", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Soldiers", new[] { "ApplicationUserId" });
            DropIndex("dbo.FirstSergeants", new[] { "ApplicationUserId" });
            DropIndex("dbo.CompanyCommanders", new[] { "ApplicationUserId" });
            DropTable("dbo.Soldiers");
            DropTable("dbo.FirstSergeants");
            DropTable("dbo.CompanyCommanders");
        }
    }
}
