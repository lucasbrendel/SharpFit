// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.User
{
    public class FitBitUser
    {
        [JsonProperty("user")]
        public Profile User { get; set; }
    }
}
