// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FitbitSDK.Resources.ActivityInfo
{

    public class Distances
    {

        [JsonProperty("activity")]
        public string Activity { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }
    }
}
