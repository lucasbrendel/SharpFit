// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharpFit.Events;
using RestSharp;
using RestSharp.Authenticators;
using SharpFit.OAuth;

namespace SharpFit.Resources.GlucoseInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class FitBitGlucose
    {
        public delegate void GlucoseGetEventHandler(object sender, GlucoseGetEventArgs e);

        public event GlucoseGetEventHandler GlucoseReceived;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("glucose")]
        public IList<Glucose> Glucose { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hba1c")]
        public double Hba1c { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        public void GetGlucose(DateTime date)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest(String.Format("/user/-/glucose/date/{0}-{1}-{2}.json", date.Year, date.Month, date.Day), Method.GET);
            request.AddHeader("Accept-Language", "en_US");
            client.ExecuteAsync(request, response =>
            {
                FitBitGlucose glucose = new FitBitGlucose();
                glucose = JsonConvert.DeserializeObject<FitBitGlucose>(response.Content);
                NotifyReceived(glucose);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="glucose"></param>
        private void NotifyReceived(FitBitGlucose glucose)
        {
            if (GlucoseReceived != null)
            {
                GlucoseReceived(this, new GlucoseGetEventArgs(glucose));
            }
        }
    }
}
