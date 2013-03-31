// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.BloodPressureInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class Bp
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("diastolic")]
        public int Diastolic { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("logId")]
        public int LogId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("systolic")]
        public int Systolic { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("time")]
        public string Time { get; set; }
    }
}
