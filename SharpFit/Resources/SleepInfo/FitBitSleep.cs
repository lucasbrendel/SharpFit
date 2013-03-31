// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.SleepInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class FitBitSleep
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sleep")]
        public IList<Sleep> Sleep { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("summary")]
        public Summary Summary { get; set; }
    }
}
