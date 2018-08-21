namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDateTmeProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyCommanders", "StartLeave", c => c.DateTime());
            AddColumn("dbo.CompanyCommanders", "EndLeave", c => c.DateTime());
            AddColumn("dbo.Soldiers", "StartDate", c => c.DateTime());
            AddColumn("dbo.Soldiers", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Soldiers", "EndDate");
            DropColumn("dbo.Soldiers", "StartDate");
            DropColumn("dbo.CompanyCommanders", "EndLeave");
            DropColumn("dbo.CompanyCommanders", "StartLeave");
        }
    }
}
