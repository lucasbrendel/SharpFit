// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.HeartRateInfo
{

    public class Average
    {

        [JsonProperty("heartRate")]
        public int HeartRate { get; set; }

        [JsonProperty("tracker")]
        public string Tracker { get; set; }
    }
}
