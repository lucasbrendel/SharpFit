// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FitbitSDK.Stats.ActivityStats
{

    public class Lifetime
    {

        [JsonProperty("total")]
        public Total Total { get; set; }

        [JsonProperty("tracker")]
        public Tracker Tracker { get; set; }
    }
}
