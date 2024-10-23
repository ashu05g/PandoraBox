namespace PandoraBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "ArtistId", c => c.Int(nullable: false));
            AddColumn("dbo.Songs", "GId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "GId");
            DropColumn("dbo.Songs", "ArtistId");
        }
    }
}
