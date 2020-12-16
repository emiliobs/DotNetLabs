using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetLabs.Server.Models
{
    public class Comments : UserRecord
    {
        [Required]
        [StringLength(5000)]
        public string Content { get; set; }

        public int Likes { get; set; }

        public virtual List<Comments> Replys { get; set; }

        public virtual Comments ParentComment { get; set; }

        [ForeignKey(nameof(ParentComment))]
        public string ParentCommentId { get; set; }

        public virtual Video Video { get; set; }

        [ForeignKey(nameof(Video))]
        public string VideoId { get; set; }

    }
}
