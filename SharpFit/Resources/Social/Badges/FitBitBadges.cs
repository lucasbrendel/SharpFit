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
    public class FitBitBadges
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("badges")]
        public IList<Badge> Badges { get; set; }
    }
}
