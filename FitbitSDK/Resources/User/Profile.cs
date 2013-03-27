using FitbitSDK.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FitbitSDK.Resources.User
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Profile : INotifyPropertyChanged
    {
        //#region Private Members
        //private string _aboutMe;
        //private string _avatar;
        //private string _city;
        //private string _country;
        //private string _dateOfBirth;
        //private string _displayName;
        //private string _distanceUnit;
        //private string _encodedID;
        //private string _foodsLocale;
        //private string _fullName;
        //private string _gender;
        //private string _glucoseUnit;
        //private double _height;
        //private string _heightUnit;
        //private string _locale;
        //private string _memberSince;
        //private string _nickname;
        //private string _offsetFromUTCMillis;
        //private string _state;
        //private int _strideLengthRunning;
        //private int _strideLengthWalking;
        //private string _timezone;
        //private string _waterUnit;
        //private double _weight;
        //private string _weightUnit; 
        //#endregion

        [JsonProperty("aboutMe")]
        public string AboutMe { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("distanceUnit")]
        public string DistanceUnit { get; set; }

        [JsonProperty("encodedId")]
        public string EncodedId { get; set; }

        [JsonProperty("foodsLocale")]
        public string FoodsLocale { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("glucoseUnit")]
        public string GlucoseUnit { get; set; }

        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("heightUnit")]
        public string HeightUnit { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("memberSince")]
        public string MemberSince { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("offsetFromUTCMillis")]
        public int OffsetFromUTCMillis { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("strideLengthRunning")]
        public int StrideLengthRunning { get; set; }

        [JsonProperty("strideLengthWalking")]
        public double StrideLengthWalking { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("waterUnit")]
        public string WaterUnit { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }

        [JsonProperty("weightUnit")]
        public string WeightUnit { get; set; }

        public BitmapImage ProfileImage
        {
            get { return new BitmapImage(new Uri(Avatar)); }
        }

        public enum Genders
        {
            MALE,
            FEMALE,
            NA
        }

        #region Public API
        /// <summary>
        /// 
        /// </summary>
        public Profile()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void GetUserInfo()
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/user/-/profile.json");
            client.ExecuteAsync(request, response =>
            {
                FitBitUser p = new FitBitUser();
                p = JsonConvert.DeserializeObject<FitBitUser>(response.Content);
                NotifyProfileComplete(p);
            });
        }

        public delegate void GetProfileHandler(object sender, ProfileEventArgs e);

        public event GetProfileHandler GetProfileCompleted;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public void UpdateUserInfo(Dictionary<string, string> param)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/user/-/profile.json", Method.POST);
            foreach (KeyValuePair<string, string> p in param)
            {
                request.AddParameter(p.Key, p.Value);
            }
            client.ExecuteAsync(request, response =>
                {
                    FitBitUser prof = new FitBitUser();
                    prof = JsonConvert.DeserializeObject<FitBitUser>(response.Content);
                    NotifyProfileComplete(prof);
                });
        } 
        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        private void NotifyProfileComplete(FitBitUser profile)
        {
            if (GetProfileCompleted != null)
            {
                GetProfileCompleted(this, new ProfileEventArgs(profile));
            }
        } 
    }

    public class ProfileEventArgs : EventArgs
    {
        private FitBitUser _profile;
        public ProfileEventArgs(FitBitUser pro)
        {
            _profile = pro;
        }

        public FitBitUser UserProfile
        {
            get { return _profile; }
        }
    }
}
