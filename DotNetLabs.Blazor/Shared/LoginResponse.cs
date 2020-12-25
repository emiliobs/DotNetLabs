using System;

namespace DotNetLabs.Blazor.Shared
{
    public class LoginResponse : BaseResponse
    {
        public string AccessToken { get; set; }

        public DateTime? ExpireDate { get; set; }

    }
}
