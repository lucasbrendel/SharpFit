// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FitbitSDK.Stats.ActivityStats
{

    public class Total
    {

        [JsonProperty("activeScore")]
        public ActiveScore ActiveScore { get; set; }

        [JsonProperty("caloriesOut")]
        public CaloriesOut CaloriesOut { get; set; }

        [JsonProperty("distance")]
        public Distance Distance { get; set; }

        [JsonProperty("floors")]
        public Floors Floors { get; set; }

        [JsonProperty("steps")]
        public Steps Steps { get; set; }
    }
}
