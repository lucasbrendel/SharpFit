// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.FoodInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class Goals
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("calories")]
        public int Calories { get; set; }
    }
}
