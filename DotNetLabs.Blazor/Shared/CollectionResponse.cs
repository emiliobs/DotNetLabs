﻿using System.Collections.Generic;

namespace DotNetLabs.Blazor.Shared
{
    public class CollectionResponse<T> : BaseResponse
    {
        public IEnumerable<T> Records { get; set; }

        public int? PageNumber { get; set; }

        public int PageSize { get; set; }

        public int? PageCount { get; set; }
    }
}
