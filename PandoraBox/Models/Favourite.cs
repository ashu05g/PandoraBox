using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandoraBox.Models
{
    public class Favourite
    {
        [Key]
        public int FId { get; set; }
        public int SId { get; set; }
        public int UId { get; set; }
        [ForeignKey("SId")]
        public virtual Song Song { get; set; }
        [ForeignKey("UId")]
        public virtual User User { get; set; }

    }
}
