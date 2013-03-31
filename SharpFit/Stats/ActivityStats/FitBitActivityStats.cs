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
    public class FitBitActivityStats
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("best")]
        public Best Best { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lifetime")]
        public Lifetime Lifetime { get; set; }
    }
}
