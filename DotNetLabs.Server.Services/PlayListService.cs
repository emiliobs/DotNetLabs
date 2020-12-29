using DotNetLabs.Blazor.Shared;
using DotNetLabs.Server.Infrastructure;
using DotNetLabs.Server.Models;
using DotNetLabs.Server.Repository;
using System;
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
            var playList = new PlayList
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

        public async Task<OperationResponse<PlayListDetail>> RemovePlayListDetailAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResponse<PlayListDetail>> UpdatePlayListDetailAsync(PlayListDetail playListDetail)
        {
            throw new NotImplementedException();
        }
    }
}
