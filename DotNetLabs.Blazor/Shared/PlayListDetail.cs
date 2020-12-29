using System.ComponentModel.DataAnnotations;

namespace DotNetLabs.Blazor.Shared
{
    public class PlayListDetail
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        //public IEnumerable<VideoDetail>  Videos { get; set; }
    }
}
