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
    public class Summary
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("totalMinutesAsleep")]
        public int TotalMinutesAsleep { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("totalSleepRecords")]
        public int TotalSleepRecords { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("totalTimeInBed")]
        public int TotalTimeInBed { get; set; }
    }
}
