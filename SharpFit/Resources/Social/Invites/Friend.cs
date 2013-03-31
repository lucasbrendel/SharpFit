// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.Social.InviteInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class Friend
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("dateTime")]
        public string DateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }
    }
}
