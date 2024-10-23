using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandoraBox.Models
{
    public interface GenreCriteria
    {
        
        List<String> meets(List<Song> songs);
    }
}
