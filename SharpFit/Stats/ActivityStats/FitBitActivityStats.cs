// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Stats.ActivityStats
{

    public class FitBitActivityStats
    {

        [JsonProperty("best")]
        public Best Best { get; set; }

        [JsonProperty("lifetime")]
        public Lifetime Lifetime { get; set; }
    }
}
