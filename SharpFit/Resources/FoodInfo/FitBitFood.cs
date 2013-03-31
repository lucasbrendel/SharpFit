// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.FoodInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class FitBitFood
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("foods")]
        public IList<Food> Foods { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("goals")]
        public Goals Goals { get; set; }
    }
}
