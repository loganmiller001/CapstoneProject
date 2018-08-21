namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeFileandBooleanPropForGoogleMapFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Soldiers", "GoogleMap", c => c.Boolean(nullable: false));
            AddColumn("dbo.Soldiers", "RouteFile", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Soldiers", "RouteFile");
            DropColumn("dbo.Soldiers", "GoogleMap");
        }
    }
}
