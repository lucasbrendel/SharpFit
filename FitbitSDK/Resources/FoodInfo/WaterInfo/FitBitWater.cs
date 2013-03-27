// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FitbitSDK.Resources.FoodInfo.WaterInfo
{

    public class FitBitWater
    {

        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        [JsonProperty("water")]
        public IList<Water> Water { get; set; }
    }
}
