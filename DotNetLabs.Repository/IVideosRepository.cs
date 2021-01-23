using DotNetLabs.Server.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLabs.Server.Repository
{
    public interface IVideosRepository
    {
        IEnumerable<Video> GetAllVideos();

        Task<Video> GetVideoByIdAsync(string id);

        Task CreateVideoAsync(Video video);

        void RemoveVideo(Video video);
    }
}
