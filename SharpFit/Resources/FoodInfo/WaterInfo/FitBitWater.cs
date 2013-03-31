// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.FoodInfo.WaterInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class FitBitWater
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("water")]
        public IList<Water> Water { get; set; }
    }
}
