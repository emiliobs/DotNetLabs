using DotNetLabs.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLabs.Server.Repository
{
    public class VideoRespositorio : IVideosRepository
    {
        private readonly ApplicationDbContext _context;

        public VideoRespositorio(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task CreateVideoAsync(Video video)
        {
            await _context.AddAsync(video);
            //await _context.SaveChangesAsync();
        }

        public IEnumerable<Video> GetAllVideos()
        {
            return  _context.Videos.ToList();
        }

        public async Task<Video> GetVideoByIdAsync(string id)
        {
            return await _context.Videos.FindAsync(id);
        }

        public void RemoveVideo(Video video)
        {
            _context.Videos.Remove(video);
            //_context.SaveChanges();
        }
    }
}
