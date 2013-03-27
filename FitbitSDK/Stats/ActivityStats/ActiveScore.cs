// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FitbitSDK.Stats.ActivityStats
{

    public class ActiveScore
    {

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }
}
