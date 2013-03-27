// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FitbitSDK.Resources.Social.InviteInfo
{

    public class Friend
    {

        [JsonProperty("dateTime")]
        public string DateTime { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
