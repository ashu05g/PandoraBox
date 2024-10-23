using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandoraBox.Models
{
    public class PlaylistSong
    {
        [Key]
        public int PSId { get; set; }
        public int PId { get; set; }
        [ForeignKey("PId")]
        public virtual Playlist Playlist { get; set; }
        public int SId { get; set; }
        [ForeignKey("SId")]
        public virtual Song Song { get; set; }
    }
}
