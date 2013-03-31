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
    public class Log
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("logId")]
        public int LogId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}
