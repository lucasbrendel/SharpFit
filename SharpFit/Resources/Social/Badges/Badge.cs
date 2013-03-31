// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.Social.BadgeInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class Badge
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("badgeType")]
        public string BadgeType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("dateTime")]
        public string DateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("image50px")]
        public string Image50px { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("image75px")]
        public string Image75px { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("timesAchieved")]
        public int TimesAchieved { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("value")]
        public int Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("unit")]
        public string Unit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
