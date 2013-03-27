// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FitbitSDK.Resources.FoodInfo.WaterInfo
{

    public class Log
    {

        [JsonProperty("logId")]
        public int LogId { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}
