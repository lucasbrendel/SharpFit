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
    public class Average
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("condition")]
        public string Condition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("diastolic")]
        public int Diastolic { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("systolic")]
        public int Systolic { get; set; }
    }
}
