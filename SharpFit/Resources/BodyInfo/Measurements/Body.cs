// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.BodyInfo.Measurements
{
    /// <summary>
    /// 
    /// </summary>
    public class Body
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bicep")]
        public int Bicep { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bmi")]
        public double Bmi { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("calf")]
        public double Calf { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("chest")]
        public int Chest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fat")]
        public int Fat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("forearm")]
        public double Forearm { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hips")]
        public int Hips { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("neck")]
        public int Neck { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("thigh")]
        public int Thigh { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("waist")]
        public int Waist { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("weight")]
        public double Weight { get; set; }
    }
}
