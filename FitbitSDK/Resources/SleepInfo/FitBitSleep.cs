// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FitbitSDK.Resources.SleepInfo
{

    public class FitBitSleep
    {

        [JsonProperty("sleep")]
        public IList<Sleep> Sleep { get; set; }

        [JsonProperty("summary")]
        public Summary Summary { get; set; }
    }
}
