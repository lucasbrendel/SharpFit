﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace SharpFit.Resources.User
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
        [JsonProperty("distanceUnit")]
        public string DistanceUnit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("encodedId")]
        public string EncodedId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("foodsLocale")]
        public string FoodsLocale { get; set; }

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
        [JsonProperty("glucoseUnit")]
        public string GlucoseUnit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("height")]
        public double Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("heightUnit")]
        public string HeightUnit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("memberSince")]
        public string MemberSince { get; set; }

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
        public double StrideLengthWalking { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("waterUnit")]
        public string WaterUnit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("weight")]
        public double Weight { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("weightUnit")]
        public string WeightUnit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BitmapImage ProfileImage
        {
            get { return new BitmapImage(new Uri(Avatar)); }
        }

        /// <summary>
        /// 
        /// </summary>
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

         
        #endregion

        #region INotifyPropertyChanged Members

        /// <summary>
        /// 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
