using DotNetLabs.Blazor.Shared;
using DotNetLabs.Server.Infrastructure;
using DotNetLabs.Server.Models;
using DotNetLabs.Server.Models.Mappers;
using DotNetLabs.Server.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLabs.Server.Services
{
    public class PlayListService : IPlayListServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IdentityOptions _identityOptions;

        public PlayListService(IUnitOfWork unitOfWork, IdentityOptions identityOptions)
        {
            _unitOfWork = unitOfWork;
            _identityOptions = identityOptions;
        }

        public async Task<OperationResponse<PlayListDetail>> CreatePlayListDetailAsync(PlayListDetail playListDetail)
        {
            PlayList playList = new PlayList
            {

                Name = playListDetail.Name,
                Description = playListDetail.Description,

            };

            await _unitOfWork.PlayList.CreatePlayListAsync(playList);
            await _unitOfWork.CommitChangesAsync(_identityOptions.UserId);

            playListDetail.Id = playList.Id;

            return new OperationResponse<PlayListDetail>
            {
                IsSuccess = true,
                Message = "PlayList created Successfully!",
                Data = playListDetail,
            };
        }

        public CollectionResponse<PlayListDetail> GetAllPlayListAsync(int pageNumber = 1, int pageSize = 10)
        {

            //Validation:
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            if (pageSize < 5)
            {
                pageSize = 5;
            }

            if (pageSize > 50)
            {
                pageSize = 50;
            }

            IEnumerable<PlayList> playLists = _unitOfWork.PlayList.GetAllPlayList();
            int playListCount = playLists.Count();

            IEnumerable<PlayListDetail> playListsInPage = playLists.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(p => p.ToPlayListDetail());


            int pageCount = playListCount / pageSize;
            if ((playListCount % pageSize) != 0)
            {
                pageCount++;
            }

            return new CollectionResponse<PlayListDetail>
            {
                IsSuccess = true,
                Message = "Playlist retrieved sccessfully",
                Records = playListsInPage.ToArray(),
                PageNumber = pageNumber,
                PageSize = pageSize,
                PageCount = pageCount,
            };

        }

        public async Task<OperationResponse<PlayListDetail>> RemovePlayListDetailAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResponse<PlayListDetail>> UpdatePlayListDetailAsync(PlayListDetail playListDetail)
        {
            var playList = await _unitOfWork.PlayList.GetPLayListByIdAsync(playListDetail.Id);

            if (playList == null)
            {
                return new OperationResponse<PlayListDetail>
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "PlayList not found!",
                };
            }

                playList.Name = playListDetail.Name;
                playList.Description = playListDetail.Description;

                await _unitOfWork.CommitChangesAsync(_identityOptions.UserId);

                return new OperationResponse<PlayListDetail> 
                {
                   IsSuccess = true,
                   Message = "Playlist has been Update Successfully!",
                   Data = playListDetail,
                };
        }
    }
}
