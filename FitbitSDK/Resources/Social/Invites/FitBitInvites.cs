// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FitbitSDK.Resources.Social.InviteInfo
{

    public class FitBitInvites
    {

        [JsonProperty("friends")]
        public IList<Friend> Friends { get; set; }
    }
}
