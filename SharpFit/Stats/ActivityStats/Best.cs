// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Stats.ActivityStats
{
    /// <summary>
    /// 
    /// </summary>
    public class Best
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("total")]
        public Total Total { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("tracker")]
        public Tracker Tracker { get; set; }
    }
}
