using PandoraBox.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace PandoraBox
{
    

    public class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PandoraBox.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public Model1()
            : base("name=Model1")
        {
            //Database.SetInitializer<>
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Album> Albums  { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Favourite> Favourites { get; set; }
        public virtual DbSet<PlaylistSong> PlaylistSongs { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}