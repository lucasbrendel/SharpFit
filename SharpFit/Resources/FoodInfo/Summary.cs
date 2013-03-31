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
    public class Summary
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("calories")]
        public int Calories { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("carbs")]
        public double Carbs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fat")]
        public int Fat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fiber")]
        public double Fiber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("protein")]
        public double Protein { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sodium")]
        public int Sodium { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("water")]
        public int Water { get; set; }
    }
}
