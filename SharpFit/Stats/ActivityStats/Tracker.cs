// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Stats.ActivityStats
{
    /// <summary>
    /// 
    /// </summary>
    public class Tracker
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("activeScore")]
        public ActiveScore ActiveScore { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("caloriesOut")]
        public CaloriesOut CaloriesOut { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("distance")]
        public Distance Distance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("floors")]
        public Floors Floors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("steps")]
        public Steps Steps { get; set; }
    }
}
