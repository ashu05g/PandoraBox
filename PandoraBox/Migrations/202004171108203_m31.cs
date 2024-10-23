namespace PandoraBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m31 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Songs", "ArtistId");
            CreateIndex("dbo.Songs", "GId");
            AddForeignKey("dbo.Songs", "ArtistId", "dbo.Artists", "ArtistId", cascadeDelete: true);
            AddForeignKey("dbo.Songs", "GId", "dbo.Genres", "GId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "GId", "dbo.Genres");
            DropForeignKey("dbo.Songs", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Songs", new[] { "GId" });
            DropIndex("dbo.Songs", new[] { "ArtistId" });
        }
    }
}
