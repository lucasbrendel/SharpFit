// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.Social.InviteInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class User
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("aboutMe")]
        public string AboutMe { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("encodedId")]
        public string EncodedId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("height")]
        public double Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("offsetFromUTCMillis")]
        public int OffsetFromUTCMillis { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("strideLengthRunning")]
        public int StrideLengthRunning { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("strideLengthWalking")]
        public int StrideLengthWalking { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("weight")]
        public double Weight { get; set; }
    }
}
