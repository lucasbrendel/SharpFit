// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FitbitSDK.Resources.FoodInfo
{

    public class NutritionalValues
    {

        [JsonProperty("calories")]
        public int Calories { get; set; }

        [JsonProperty("carbs")]
        public double Carbs { get; set; }

        [JsonProperty("fat")]
        public int Fat { get; set; }

        [JsonProperty("fiber")]
        public double Fiber { get; set; }

        [JsonProperty("protein")]
        public double Protein { get; set; }

        [JsonProperty("sodium")]
        public int Sodium { get; set; }
    }
}
