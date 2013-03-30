// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.BodyInfo.Measurements
{

    public class Body
    {

        [JsonProperty("bicep")]
        public int Bicep { get; set; }

        [JsonProperty("bmi")]
        public double Bmi { get; set; }

        [JsonProperty("calf")]
        public double Calf { get; set; }

        [JsonProperty("chest")]
        public int Chest { get; set; }

        [JsonProperty("fat")]
        public int Fat { get; set; }

        [JsonProperty("forearm")]
        public double Forearm { get; set; }

        [JsonProperty("hips")]
        public int Hips { get; set; }

        [JsonProperty("neck")]
        public int Neck { get; set; }

        [JsonProperty("thigh")]
        public int Thigh { get; set; }

        [JsonProperty("waist")]
        public int Waist { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }
    }
}
