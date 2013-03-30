// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.SleepInfo
{

    public class Summary
    {

        [JsonProperty("totalMinutesAsleep")]
        public int TotalMinutesAsleep { get; set; }

        [JsonProperty("totalSleepRecords")]
        public int TotalSleepRecords { get; set; }

        [JsonProperty("totalTimeInBed")]
        public int TotalTimeInBed { get; set; }
    }
}
