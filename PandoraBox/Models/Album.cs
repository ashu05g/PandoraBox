﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandoraBox.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
    }
}
