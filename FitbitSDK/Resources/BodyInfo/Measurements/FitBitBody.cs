using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FitbitSDK.OAuth;
using RestSharp;
using RestSharp.Authenticators;

namespace FitbitSDK.Resources.BodyInfo.Measurements
{
    /// <summary>
    /// 
    /// </summary>
    public class FitBitBody
    {

        /// <summary>
        /// Body measurements
        /// </summary>
        [JsonProperty("body")]
        public Body Body { get; set; }

        /// <summary>
        /// User goals
        /// </summary>
        [JsonProperty("goals")]
        public Goals Goals { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FitBitBody()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        public void GetBodyMeasurements(DateTime date)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest(String.Format("/user/-/body/date/{0}-{1}-{2}.json", date.Year, date.Month, date.Day), Method.GET);
            client.ExecuteAsync(request, response =>
            {
                FitBitBody b = new FitBitBody();
                b.Body = JsonConvert.DeserializeObject<Body>(response.Content);
                NotifyGetComplete(b);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void GetMeasurementsEventHandler(object sender, BodyMeasurementsEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        public event GetMeasurementsEventHandler MeasurementsReceived;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measurements"></param>
        public void NotifyGetComplete(FitBitBody measurements)
        {
            if (MeasurementsReceived != null)
            {
                MeasurementsReceived(this, new BodyMeasurementsEventArgs(measurements));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class BodyMeasurementsEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public FitBitBody Measurements;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measurements"></param>
        public BodyMeasurementsEventArgs(FitBitBody measurements)
        {
            this.Measurements = measurements;
        }
    }
}
