using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandoraBox.Models
{
    class Sufi : GenreCriteria
    {
        Model1 m = new Model1();
        public List<String> meets(List<Song> songs)
        {
            return m.Songs.Where(s => s.Genre.Name == "Sufi").Select(u => u.SName).ToList();
        }
    }
    
}
