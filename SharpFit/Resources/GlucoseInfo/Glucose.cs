// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.GlucoseInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class Glucose
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("glucose")]
        public double Glucoses { get; set; }

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
