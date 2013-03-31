// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.User
{
    /// <summary>
    /// 
    /// </summary>
    public class FitBitUser
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("user")]
        public Profile User { get; set; }
    }
}
