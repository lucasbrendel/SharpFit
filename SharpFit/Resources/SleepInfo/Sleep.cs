// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.SleepInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class Sleep
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("isMainSleep")]
        public bool IsMainSleep { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("logId")]
        public int LogId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("efficiency")]
        public int Efficiency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("startTime")]
        public string StartTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("minutesToFallAsleep")]
        public int MinutesToFallAsleep { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("minutesAsleep")]
        public int MinutesAsleep { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("minutesAwake")]
        public int MinutesAwake { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("minutesAfterWakeup")]
        public int MinutesAfterWakeup { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("awakeningsCount")]
        public int AwakeningsCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("timeInBed")]
        public int TimeInBed { get; set; }
    }
}
