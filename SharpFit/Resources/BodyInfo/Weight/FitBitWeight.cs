// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.BodyInfo.Weight
{
    /// <summary>
    /// 
    /// </summary>
    public class FitBitWeight
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("weight")]
        public IList<Weight> Weight { get; set; }
    }
}
