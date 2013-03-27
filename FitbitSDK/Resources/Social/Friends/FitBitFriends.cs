// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FitbitSDK.Resources.Social.FriendInfo
{

    public class FitBitFriends
    {

        [JsonProperty("friends")]
        public IList<Friend> Friends { get; set; }
    }
}
