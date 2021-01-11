using DotNetLabs.Blazor.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLabs.Server.Models.Mappers
{
    public static class PlayListsMapper
    {
        public static PlayListDetail ToPlayListDetail(this PlayList playList)
        {
            return new PlayListDetail 
            {
               Id = playList.Id,
               Description = playList.Description,
               Name = playList.Name,
            };
        }
    }
}
