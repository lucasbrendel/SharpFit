// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.SleepInfo
{

    public class Sleep
    {

        [JsonProperty("isMainSleep")]
        public bool IsMainSleep { get; set; }

        [JsonProperty("logId")]
        public int LogId { get; set; }

        [JsonProperty("efficiency")]
        public int Efficiency { get; set; }

        [JsonProperty("startTime")]
        public string StartTime { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("minutesToFallAsleep")]
        public int MinutesToFallAsleep { get; set; }

        [JsonProperty("minutesAsleep")]
        public int MinutesAsleep { get; set; }

        [JsonProperty("minutesAwake")]
        public int MinutesAwake { get; set; }

        [JsonProperty("minutesAfterWakeup")]
        public int MinutesAfterWakeup { get; set; }

        [JsonProperty("awakeningsCount")]
        public int AwakeningsCount { get; set; }

        [JsonProperty("timeInBed")]
        public int TimeInBed { get; set; }
    }
}
