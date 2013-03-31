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
    public class Average
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("heartRate")]
        public int HeartRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("tracker")]
        public string Tracker { get; set; }
    }
}
