namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBoolPropertiesforDA31andLESForms : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Soldiers", "LeaveFormSubmission", c => c.Boolean(nullable: false));
            AddColumn("dbo.Soldiers", "LESSubmission", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Soldiers", "LESSubmission");
            DropColumn("dbo.Soldiers", "LeaveFormSubmission");
        }
    }
}
