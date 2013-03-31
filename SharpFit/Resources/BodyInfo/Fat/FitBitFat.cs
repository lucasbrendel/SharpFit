// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.BodyInfo.Fat
{
    /// <summary>
    /// 
    /// </summary>
    public class FitBitFat
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fat")]
        public IList<Fat> Fat { get; set; }
    }
}
