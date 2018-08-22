namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TookOutLatandLongPropertiesinSoldierModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Soldiers", "GoogleMap");
            DropColumn("dbo.Soldiers", "RouteFile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Soldiers", "RouteFile", c => c.String());
            AddColumn("dbo.Soldiers", "GoogleMap", c => c.Boolean(nullable: false));
        }
    }
}
