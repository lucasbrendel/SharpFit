// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.BodyInfo.Fat
{

    public class FitBitFat
    {

        [JsonProperty("fat")]
        public IList<Fat> Fat { get; set; }
    }
}
