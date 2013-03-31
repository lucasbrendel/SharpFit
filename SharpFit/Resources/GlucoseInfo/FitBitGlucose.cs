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
    public class FitBitGlucose
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("glucose")]
        public IList<Glucose> Glucose { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hba1c")]
        public double Hba1c { get; set; }
    }
}
