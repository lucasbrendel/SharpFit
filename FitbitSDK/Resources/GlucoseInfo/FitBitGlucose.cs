// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FitbitSDK.Resources.GlucoseInfo
{

    public class FitBitGlucose
    {

        [JsonProperty("glucose")]
        public IList<Glucose> Glucose { get; set; }

        [JsonProperty("hba1c")]
        public double Hba1c { get; set; }
    }
}
