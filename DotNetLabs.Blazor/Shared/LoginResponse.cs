using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetLabs.Blazor.Shared
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }

        public DateTime? ExpireDate { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}
