using Newtonsoft.Json;
using Rebrandly.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rebrandly.Services.Base
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BaseOptions : INestedOptions
    {
    }
}
