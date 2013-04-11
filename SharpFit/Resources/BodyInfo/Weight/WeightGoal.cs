using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.BodyInfo.Weight
{

    public class WeightGoal
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("startWeight")]
        public int StartWeight { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("weight")]
        public int Weight { get; set; }
    }

}
