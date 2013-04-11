using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharpFit.Events;
using RestSharp;
using RestSharp.Authenticators;
using System.ComponentModel;
using SharpFit.OAuth;
using SharpFit;

namespace SharpFit.Resources.BodyInfo.Weight
{
    /// <summary>
    /// 
    /// </summary>
    public class FitBitWeight
    {
        public delegate void BodyWeightGetEventHandler(object sender, BodyWeightGetEventArgs e);

        public event BodyWeightGetEventHandler BodyWeightReceived;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("weight")]
        public IList<Weight> Weights { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FitBitWeight()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="weight"></param>
        public FitBitWeight(IList<Weight> weight)
        {
            this.Weights = weight;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        public void GetBodyWeight(DateTime date)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest(String.Format("/user/-/body/log/weight/date/{0}-{1}-{2}.json", date.Year, date.Month, date.Day), Method.GET);
            client.ExecuteAsync(request, response =>
            {
                FitBitWeight w = new FitBitWeight();
                w = JsonConvert.DeserializeObject<FitBitWeight>(response.Content);
                NotifyReceived(w);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public void GetBodyWeight(DateTime startDate, DateTime endDate)
        {
            if(Math.Abs((startDate.Date - endDate.Date).Days) > 31)
            {
                throw new ArgumentOutOfRangeException();
            }
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest(String.Format("/user/-/body/log/weight/date/{0}-{1}-{2}/{3}-{4}-{5}.json", startDate.Year, startDate.Month, startDate.Day, 
                endDate.Year, endDate.Month, endDate.Minute), Method.GET);
            client.ExecuteAsync(request, response =>
            {
                FitBitWeight w = new FitBitWeight();
                w = JsonConvert.DeserializeObject<FitBitWeight>(response.Content);
                NotifyReceived(w);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="period"></param>
        public void GetBodyWeight(DateTime startDate, TimePeriod period)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);

            switch(period)
            {
                case TimePeriod.OneDay:
                    request = new RestRequest(String.Format("/user/-/body/log/weight/date/{0}-{1}-{2}/1d.json", startDate.Year, startDate.Month, startDate.Day), Method.GET);
                    break;
                case TimePeriod.OneMonth:
                    request = new RestRequest(String.Format("/user/-/body/log/weight/date/{0}-{1}-{2}/1m.json", startDate.Year, startDate.Month, startDate.Day), Method.GET);
                    break;
                case TimePeriod.OneWeek:
                    request = new RestRequest(String.Format("/user/-/body/log/weight/date/{0}-{1}-{2}/1w.json", startDate.Year, startDate.Month, startDate.Day), Method.GET);
                    break;
                case TimePeriod.SevenDays:
                    request = new RestRequest(String.Format("/user/-/body/log/weight/date/{0}-{1}-{2}/7d.json", startDate.Year, startDate.Month, startDate.Day), Method.GET);
                    break;
                case TimePeriod.ThirtyDays:
                    request = new RestRequest(String.Format("/user/-/body/log/weight/date/{0}-{1}-{2}/30d.json", startDate.Year, startDate.Month, startDate.Day), Method.GET);
                    break;
                default:
                    throw new ArgumentException("An incorrect enum has been given as a parameter", "period");
            }

            client.ExecuteAsync(request, response =>
            {
                FitBitWeight w = new FitBitWeight();
                w = JsonConvert.DeserializeObject<FitBitWeight>(response.Content);
                NotifyReceived(w);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="weight"></param>
        private void NotifyReceived(FitBitWeight weight)
        {
            if (BodyWeightReceived != null)
            {
                BodyWeightReceived(this, new BodyWeightGetEventArgs(weight));
            }
        }
    }
}
