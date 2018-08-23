namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TookOutStartandEndpointProperties : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Soldiers", "StartPoint");
            DropColumn("dbo.Soldiers", "EndPoint");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Soldiers", "EndPoint", c => c.Double(nullable: false));
            AddColumn("dbo.Soldiers", "StartPoint", c => c.Double(nullable: false));
        }
    }
}
