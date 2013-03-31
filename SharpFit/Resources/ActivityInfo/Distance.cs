// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.ActivityInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class Distances
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("activity")]
        public string Activity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("distance")]
        public double Distance { get; set; }
    }
}
