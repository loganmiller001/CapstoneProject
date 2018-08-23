namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFileToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileID = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        SoldierIdentification = c.Int(nullable: false),
                        Soldier_SoldierId = c.Int(),
                    })
                .PrimaryKey(t => t.FileID)
                .ForeignKey("dbo.Soldiers", t => t.Soldier_SoldierId)
                .Index(t => t.Soldier_SoldierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "Soldier_SoldierId", "dbo.Soldiers");
            DropIndex("dbo.Files", new[] { "Soldier_SoldierId" });
            DropTable("dbo.Files");
        }
    }
}
