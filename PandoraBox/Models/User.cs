using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandoraBox.Models
{
    public class User
    {
        [Key]
        public int UId { get; set; }
        public string UName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public  string Password { get; set; }
    }
}
