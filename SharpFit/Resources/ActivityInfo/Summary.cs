// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.ActivityInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class Summary
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("activeScore")]
        public int ActiveScore { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("activityCalories")]
        public int ActivityCalories { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("caloriesOut")]
        public int CaloriesOut { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("distances")]
        public IList<Distances> Distances { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("elevation")]
        public double Elevation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fairlyActiveMinutes")]
        public int FairlyActiveMinutes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("floors")]
        public int Floors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lightlyActiveMinutes")]
        public int LightlyActiveMinutes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("marginalCalories")]
        public int MarginalCalories { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sedentaryMinutes")]
        public int SedentaryMinutes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("steps")]
        public int Steps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("veryActiveMinutes")]
        public int VeryActiveMinutes { get; set; }
    }
}
