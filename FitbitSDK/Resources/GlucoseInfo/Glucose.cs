// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FitbitSDK.Resources.GlucoseInfo
{

    public class Glucose
    {

        [JsonProperty("glucose")]
        public double Glucoses { get; set; }

        [JsonProperty("tracker")]
        public string Tracker { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
}
