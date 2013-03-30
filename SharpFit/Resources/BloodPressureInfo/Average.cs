// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.BloodPressureInfo
{

    public class Average
    {

        [JsonProperty("condition")]
        public string Condition { get; set; }

        [JsonProperty("diastolic")]
        public int Diastolic { get; set; }

        [JsonProperty("systolic")]
        public int Systolic { get; set; }
    }
}
