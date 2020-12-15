using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotNetLabs.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            CreatePlayLists = new List<PlayList>();
            ModifiedPlayLists = new List<PlayList>();
        }

        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }
    
        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

        //Relationsships
        public virtual List<PlayList>  CreatePlayLists{ get; set; }
        
        public virtual List<PlayList>  ModifiedPlayLists { get; set; }

        public virtual List<Video> CreateVideos { get; set; }

        public virtual List<Video> ModifiedVideos { get; set; }

    }
}
