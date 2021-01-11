using DotNetLabs.Blazor.Shared;

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
