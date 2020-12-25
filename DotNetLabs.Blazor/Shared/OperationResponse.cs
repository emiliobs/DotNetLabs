namespace DotNetLabs.Blazor.Shared
{
    public class OperationResponse<T> : BaseResponse
    {
        public T Data { get; set; }
    }
}
