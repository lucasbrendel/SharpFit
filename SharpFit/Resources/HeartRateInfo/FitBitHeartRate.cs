// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using SharpFit.OAuth;
using SharpFit.Events;

namespace SharpFit.Resources.HeartRateInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class FitBitHeartRate
    {
        public delegate void HeartRateGetHandler(object sender, HeartRateEventArgs e);

        public event HeartRateGetHandler HeartRateReceived;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("average")]
        public IList<Average> Average { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("heart")]
        public IList<Heart> Heart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FitBitHeartRate()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="averages"></param>
        /// <param name="heartLogs"></param>
        public FitBitHeartRate(IList<Average> averages, IList<Heart> heartLogs)
        {
            this.Average = averages;
            this.Heart = heartLogs;
        }

        /// <summary>
        /// Get the users heart rates from a specific date
        /// </summary>
        /// <param name="date">The day of heart rates to get</param>
        public void GetHeartRate(DateTime date)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest(String.Format("/user/-/heart/date/{0}-{1}-{2}.json", date.Year, date.Month, date.Day), Method.GET);
            request.AddHeader("Accept-Language", "en_US");
            client.ExecuteAsync(request, response =>
                {
                    FitBitHeartRate heart = new FitBitHeartRate();
                    heart = JsonConvert.DeserializeObject<FitBitHeartRate>(response.Content);
                    NotifyDownloaded(heart);
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        public void LogHeartRate(Dictionary<string, string> parameters)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="tracker"></param>
        /// <param name="heartRate"></param>
        public void LogHeartRate(DateTime date, string tracker, int heartRate)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="tracker"></param>
        /// <param name="heartRate"></param>
        /// <param name="time"></param>
        public void LogHeartRate(DateTime date, string tracker, int heartRate, DateTime time)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="heartInfo"></param>
        /// <param name="date"></param>
        public void LogHeartRate(Heart heartInfo, DateTime date)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logId"></param>
        public void DeleteHeartRate(int logId)
        {
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="heartRate"></param>
        public void NotifyDownloaded(FitBitHeartRate heartRate)
        {
            if (HeartRateReceived != null)
            {
                HeartRateReceived(this, new HeartRateEventArgs(heartRate));
            }
        }
    }
}
