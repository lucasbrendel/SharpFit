// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FitbitSDK.Resources.Social.FriendInfo
{

    public class User
    {

        [JsonProperty("aboutMe")]
        public string AboutMe { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        public BitmapImage AvatarImage
        {
            get { return new BitmapImage(new Uri(Avatar)); }
        }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("encodedId")]
        public string EncodedId { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("offsetFromUTCMillis")]
        public int OffsetFromUTCMillis { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("strideLengthRunning")]
        public int StrideLengthRunning { get; set; }

        [JsonProperty("strideLengthWalking")]
        public int StrideLengthWalking { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }
    }
}
