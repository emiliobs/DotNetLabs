using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLabs.Blazor.Shared
{
    public enum VideosPrivacy
    {
        Public = 1, //Available For everyone
        Unlisted = 2,//Available only through URl
        Private = 3 //Cannot be seen
    }
}
