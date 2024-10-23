namespace PandoraBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        FId = c.Int(nullable: false, identity: true),
                        SId = c.Int(nullable: false),
                        UId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FId)
                .ForeignKey("dbo.Songs", t => t.SId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UId, cascadeDelete: true)
                .Index(t => t.SId)
                .Index(t => t.UId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favourites", "UId", "dbo.Users");
            DropForeignKey("dbo.Favourites", "SId", "dbo.Songs");
            DropIndex("dbo.Favourites", new[] { "UId" });
            DropIndex("dbo.Favourites", new[] { "SId" });
            DropTable("dbo.Favourites");
        }
    }
}
