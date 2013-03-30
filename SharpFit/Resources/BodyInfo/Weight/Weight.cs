// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.BodyInfo.Weight
{

    public class Weight
    {

        [JsonProperty("bmi")]
        public double Bmi { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("logId")]
        public object LogId { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("weight")]
        public double Weights { get; set; }
    }
}
