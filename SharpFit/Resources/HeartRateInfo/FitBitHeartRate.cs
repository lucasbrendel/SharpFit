// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.HeartRateInfo
{

    public class FitBitHeartRate
    {

        [JsonProperty("average")]
        public IList<Average> Average { get; set; }

        [JsonProperty("heart")]
        public IList<Heart> Heart { get; set; }
    }
}
