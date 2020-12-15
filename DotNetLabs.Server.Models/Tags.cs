﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotNetLabs.Server.Models
{
    public class Tags : Record
    {
        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        public virtual Video Video { get; set; }

        public string VideoId { get; set; }
    }
}
