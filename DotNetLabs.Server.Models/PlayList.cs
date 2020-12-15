using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetLabs.Server.Models
{
    public class PlayList : UserRecord
    {
       
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [StringLength(5000)]
        public string Description { get; set; }

        public virtual List<PlayListVideo> PlayListVideos { get; set; }


    }
}
