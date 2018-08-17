namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSoldierPropertyBoolLeaveStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Soldiers", "PacketStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Soldiers", "PacketStatus");
        }
    }
}
