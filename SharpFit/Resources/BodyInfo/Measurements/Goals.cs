// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.BodyInfo.Measurements
{

    public class Goals
    {

        [JsonProperty("weight")]
        public int Weight { get; set; }
    }
}
