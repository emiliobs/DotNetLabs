using DotNetLabs.Blazor.Shared;
using System.Threading.Tasks;

namespace DotNetLabs.Server.Services
{
    public interface IPlayListServices
    {
        Task<OperationResponse<PlayListDetail>> CreatePlayListDetailAsync(PlayListDetail playListDetail);

        Task<OperationResponse<PlayListDetail>> UpdatePlayListDetailAsync(PlayListDetail playListDetail);

        Task<OperationResponse<PlayListDetail>> RemovePlayListDetailAsync(string id);

        CollectionResponse<PlayListDetail> GetAllPlayListAsync(int pageNumber, int pageSize);

        //Task<OperationResponse<PlayListDetail>> (PlayListDetail PlayListDetail);
    }
}
