using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandoraBox.Models;

namespace PandoraBox.Models
{
    public class Remix : GenreCriteria
    {
        Model1 m = new Model1();
        public List<String> meets(List<Song> songs)
        {
            return m.Songs.Where(s => s.Genre.Name == "Remix").Select(u => u.SName).ToList();
        }
    }
}
