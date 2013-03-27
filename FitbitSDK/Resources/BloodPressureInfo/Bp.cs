// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FitbitSDK.Resources.BloodPressureInfo
{

    public class Bp
    {

        [JsonProperty("diastolic")]
        public int Diastolic { get; set; }

        [JsonProperty("logId")]
        public int LogId { get; set; }

        [JsonProperty("systolic")]
        public int Systolic { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
}
