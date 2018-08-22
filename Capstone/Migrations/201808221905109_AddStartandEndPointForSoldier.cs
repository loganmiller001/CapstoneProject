namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStartandEndPointForSoldier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Soldiers", "StartPoint", c => c.Double(nullable: false));
            AddColumn("dbo.Soldiers", "EndPoint", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Soldiers", "EndPoint");
            DropColumn("dbo.Soldiers", "StartPoint");
        }
    }
}
