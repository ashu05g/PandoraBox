using PandoraBox.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
//using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using PandoraBox.Home;
namespace PandoraBox
{
    public class Song
    {
        [Key]
        public int SId { get; set; }
        public string SName { get; set; }
        public double Duration { get; set; }
        public string Photo { get; set; }
        
        public int AlbumId { get; set; }
        [ForeignKey("AlbumId")]
        public virtual Album Album { get; set; }

        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public virtual Artist Artist { get; set; }

        public int GId { get; set; }
        [ForeignKey("GId")]
        public virtual Genre Genre { get; set; }

        //public Song displaySong(string SName1)
        //{
        //    Model1 m = new Model1();
        //    Song s = m.Songs.SingleOrDefault(x => x.SName == SName1);
        //    return s;
        //}

    }
}
