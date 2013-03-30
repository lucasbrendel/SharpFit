// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.FoodInfo
{

    public class FitBitFood
    {

        [JsonProperty("foods")]
        public IList<Food> Foods { get; set; }

        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        [JsonProperty("goals")]
        public Goals Goals { get; set; }
    }
}
