namespace PandoraBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        AlbumName = c.String(),
                    })
                .PrimaryKey(t => t.AlbumId);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Artistd = c.Int(nullable: false, identity: true),
                        ArtistName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Artistd);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GId);
            
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        PId = c.Int(nullable: false, identity: true),
                        PName = c.String(),
                        UId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PId)
                .ForeignKey("dbo.Users", t => t.UId, cascadeDelete: true)
                .Index(t => t.UId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UId = c.Int(nullable: false, identity: true),
                        UName = c.String(),
                        Email = c.String(),
                        Photo = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Playlists", "UId", "dbo.Users");
            DropIndex("dbo.Playlists", new[] { "UId" });
            DropTable("dbo.Users");
            DropTable("dbo.Playlists");
            DropTable("dbo.Genres");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
