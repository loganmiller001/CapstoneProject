namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPropertiesForTravelDocumentsinSoldier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Soldiers", "TravelInfo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Soldiers", "TravelFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Soldiers", "TravelFileName");
            DropColumn("dbo.Soldiers", "TravelInfo");
        }
    }
}
