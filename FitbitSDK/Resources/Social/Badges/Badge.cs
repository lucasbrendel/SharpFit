// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FitbitSDK.Resources.Social.BadgeInfo
{

    public class Badge
    {

        [JsonProperty("badgeType")]
        public string BadgeType { get; set; }

        [JsonProperty("dateTime")]
        public string DateTime { get; set; }

        [JsonProperty("image50px")]
        public string Image50px { get; set; }

        [JsonProperty("image75px")]
        public string Image75px { get; set; }

        [JsonProperty("timesAchieved")]
        public int TimesAchieved { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
