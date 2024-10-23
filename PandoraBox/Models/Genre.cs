using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandoraBox.Models
{
    public class Genre
    {
        [Key]
        public int GId { get; set; }
        public string Name { get; set; }
    }
}
