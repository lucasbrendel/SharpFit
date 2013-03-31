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
    public class ActiveScore
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("date")]
        public string Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("value")]
        public int Value { get; set; }
    }
}
