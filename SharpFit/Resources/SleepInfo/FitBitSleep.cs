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

namespace SharpFit.Resources.SleepInfo
{
    public class FitBitSleep
    {
        public delegate void SleepGetEventHandler(object sender, SleepGetEventArgs e);

        public event SleepGetEventHandler SleepReceived;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sleep")]
        public IList<Sleep> Sleep { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        public void GetSleep(DateTime date)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest(String.Format("/user/-/glucose/date/{0}-{1}-{2}.json", date.Year, date.Month, date.Day), Method.GET);
            request.AddHeader("Accept-Language", "en_US");
            client.ExecuteAsync(request, response =>
            {
                FitBitSleep sleep = new FitBitSleep();
                sleep = JsonConvert.DeserializeObject<FitBitSleep>(response.Content);
                NotifyReceived(sleep);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sleep"></param>
        private void NotifyReceived(FitBitSleep sleep)
        {
            if (SleepReceived != null)
            {
                SleepReceived(this, new SleepGetEventArgs(sleep));
            }
        }
    }
}
