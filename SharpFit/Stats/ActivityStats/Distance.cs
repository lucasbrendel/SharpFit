// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Stats.ActivityStats
{

    public class Distance
    {

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }
}
