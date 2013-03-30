// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.HeartRateInfo
{

    public class Heart
    {

        [JsonProperty("heartRate")]
        public int HeartRate { get; set; }

        [JsonProperty("logId")]
        public int LogId { get; set; }

        [JsonProperty("tracker")]
        public string Tracker { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
}
