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
    public class FitBitBloodPressure
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("average")]
        public Average Average { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bp")]
        public IList<Bp> Bp { get; set; }
    }
}
