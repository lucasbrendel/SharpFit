// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FitbitSDK.Resources.BodyInfo.Fat
{

    public class Fat
    {

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("fat")]
        public double Fats { get; set; }

        [JsonProperty("logId")]
        public object LogId { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
}
