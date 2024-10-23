namespace PandoraBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Artists");
            DropColumn("dbo.Artists", "Artistd");

            CreateTable(
                "dbo.PlaylistSongs",
                c => new
                    {
                        PSId = c.Int(nullable: false, identity: true),
                        PId = c.Int(nullable: false),
                        SId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PSId)
                .ForeignKey("dbo.Playlists", t => t.PId, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.SId, cascadeDelete: true)
                .Index(t => t.PId)
                .Index(t => t.SId);
            
            AddColumn("dbo.Artists", "ArtistId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Artists", "ArtistId");

            AlterColumn("dbo.Artists", "ArtistName", c => c.String());
            AlterColumn("dbo.Songs", "Duration", c => c.Double(nullable: false));
            CreateIndex("dbo.Songs", "AlbumId");
            AddForeignKey("dbo.Songs", "AlbumId", "dbo.Albums", "AlbumId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artists", "Artistd", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.PlaylistSongs", "SId", "dbo.Songs");
            DropForeignKey("dbo.Songs", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.PlaylistSongs", "PId", "dbo.Playlists");
            DropIndex("dbo.Songs", new[] { "AlbumId" });
            DropIndex("dbo.PlaylistSongs", new[] { "SId" });
            DropIndex("dbo.PlaylistSongs", new[] { "PId" });
            DropPrimaryKey("dbo.Artists");
            AlterColumn("dbo.Songs", "Duration", c => c.Int(nullable: false));
            AlterColumn("dbo.Artists", "ArtistName", c => c.Int(nullable: false));
            DropColumn("dbo.Artists", "ArtistId");
            DropTable("dbo.PlaylistSongs");
            AddPrimaryKey("dbo.Artists", "Artistd");
        }
    }
}
