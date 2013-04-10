// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharpFit.Events;
using SharpFit.OAuth;
using RestSharp;
using RestSharp.Authenticators;

namespace SharpFit.Resources.BodyInfo.Fat
{
    /// <summary>
    /// 
    /// </summary>
    public class FitBitFat
    {
        public delegate void BodyFatReceivedEventHandler(object sender, BodyFatEventArgs e);

        public event BodyFatReceivedEventHandler BodyFatReceived;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fat")]
        public IList<Fat> Fats { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FitBitFat()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fat"></param>
        public FitBitFat(IList<Fat> fat)
        {
            this.Fats = fat;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        public void GetBodyFat(DateTime date)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest(String.Format("/user/-/body/log/fat/date/{0}-{1}-{2}.json", date.Year, date.Month, date.Day), Method.GET);
            client.ExecuteAsync(request, response =>
            {
                FitBitFat w = new FitBitFat();
                w = JsonConvert.DeserializeObject<FitBitFat>(response.Content);
                NotifyReceived(w);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public void GetBodyFat(DateTime startDate, DateTime endDate)
        {
            if (Math.Abs((startDate.Date - endDate.Date).Days) > 31)
            {
                throw new ArgumentOutOfRangeException();
            }
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest(String.Format("/user/-/body/log/fat/date/{0}-{1}-{2}/{3}-{4}-{5}.json", startDate.Year, startDate.Month, startDate.Day,
                endDate.Year, endDate.Month, endDate.Minute), Method.GET);
            client.ExecuteAsync(request, response =>
            {
                FitBitFat w = new FitBitFat();
                w = JsonConvert.DeserializeObject<FitBitFat>(response.Content);
                NotifyReceived(w);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="period"></param>
        public void GetBodyFat(DateTime startDate, TimePeriod period)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);

            switch (period)
            {
                case TimePeriod.OneDay:
                    request = new RestRequest(String.Format("/user/-/body/log/fat/date/{0}-{1}-{2}/1d.json", startDate.Year, startDate.Month, startDate.Day), Method.GET);
                    break;
                case TimePeriod.OneMonth:
                    request = new RestRequest(String.Format("/user/-/body/log/fat/date/{0}-{1}-{2}/1m.json", startDate.Year, startDate.Month, startDate.Day), Method.GET);
                    break;
                case TimePeriod.OneWeek:
                    request = new RestRequest(String.Format("/user/-/body/log/fat/date/{0}-{1}-{2}/1w.json", startDate.Year, startDate.Month, startDate.Day), Method.GET);
                    break;
                case TimePeriod.SevenDays:
                    request = new RestRequest(String.Format("/user/-/body/log/fat/date/{0}-{1}-{2}/7d.json", startDate.Year, startDate.Month, startDate.Day), Method.GET);
                    break;
                case TimePeriod.ThirtyDays:
                    request = new RestRequest(String.Format("/user/-/body/log/fat/date/{0}-{1}-{2}/30d.json", startDate.Year, startDate.Month, startDate.Day), Method.GET);
                    break;
                default:
                    throw new ArgumentException("An incorrect enum has been given as a parameter", "period");
            }

            client.ExecuteAsync(request, response =>
            {
                FitBitFat f = new FitBitFat();
                f = JsonConvert.DeserializeObject<FitBitFat>(response.Content);
                NotifyReceived(f);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fats"></param>
        private void NotifyReceived(FitBitFat fats)
        {
            if (BodyFatReceived != null)
            {
                BodyFatReceived(this, new BodyFatEventArgs(fats));
            }
        }
    }
}
