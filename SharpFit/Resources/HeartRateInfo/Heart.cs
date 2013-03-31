// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.HeartRateInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class Heart
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("heartRate")]
        public int HeartRate { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("logId")]
        public int LogId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("tracker")]
        public string Tracker { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("time")]
        public string Time { get; set; }
    }
}
