using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.ActivityInfo
{

    public class DailyGoals
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("caloriesOut")]
        public int CaloriesOut { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("distance")]
        public double Distance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("floors")]
        public int Floors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("steps")]
        public int Steps { get; set; }
    }

}
