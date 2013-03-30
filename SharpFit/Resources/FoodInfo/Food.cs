// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.FoodInfo
{

    public class Food
    {

        [JsonProperty("isFavorite")]
        public bool IsFavorite { get; set; }

        [JsonProperty("logDate")]
        public string LogDate { get; set; }

        [JsonProperty("logId")]
        public int LogId { get; set; }

        [JsonProperty("loggedFood")]
        public LoggedFood LoggedFood { get; set; }

        [JsonProperty("nutritionalValues")]
        public NutritionalValues NutritionalValues { get; set; }
    }
}
