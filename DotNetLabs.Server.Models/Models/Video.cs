using DotNetLabs.Blazor.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNetLabs.Server.Models
{
    public class Video : UserRecord
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string VideoUrl { get; set; }

        [Required]
        [StringLength(255)]

        public string ThumpUrl { get; set; }

        public int Views { get; set; }

        public int Likes { get; set; }

        public DateTime PublishingDate { get; set; }

        public Category Category { get; set; }

        public VideosPrivacy Privacy { get; set; }

        public virtual List<PlayListVideo> PlayListVideos { get; set; }

        public virtual List<Tags> Tags { get; set; }

        public virtual List<Comments> Comments { get; set; }

    }
}
