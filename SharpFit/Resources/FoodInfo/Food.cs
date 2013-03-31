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
    public class Food
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("isFavorite")]
        public bool IsFavorite { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("logDate")]
        public string LogDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("logId")]
        public int LogId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("loggedFood")]
        public LoggedFood LoggedFood { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nutritionalValues")]
        public NutritionalValues NutritionalValues { get; set; }
    }
}
