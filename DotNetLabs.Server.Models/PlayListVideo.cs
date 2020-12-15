using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLabs.Server.Models
{
    public class PlayListVideo : Record
    {
        public virtual Video Video { get; set; }

        public string VideoId  { get; set; }

        public virtual PlayList  PlayList { get; set; }

        public string PlayListId { get; set; }
    }
}
