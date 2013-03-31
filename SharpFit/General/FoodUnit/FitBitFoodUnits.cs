// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using SharpFit.OAuth;

namespace SharpFit.General.FoodUnit
{
    /// <summary>
    /// 
    /// </summary>
    public class FitBitFoodUnits
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("units")]
        public IList<Unit> Units { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public void GetFoodUnits()
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/foods/units.json", Method.GET);
            client.ExecuteAsync(request, response =>
            {
                //FitBitFoodUnits units = new FitBitFoodUnits();
                IList<Unit> units = JsonConvert.DeserializeObject<IList<Unit>>(response.Content);
                NotifyReceived(units);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void FoodUnitsReceivedEventHander(object sender, FoodUnitsReceivedEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        public event FoodUnitsReceivedEventHander FoodUnitsReceived;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="units"></param>
        public void NotifyReceived(IList<Unit> units)
        {
            if (FoodUnitsReceived != null)
            {
                FoodUnitsReceived(this, new FoodUnitsReceivedEventArgs(units));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class FoodUnitsReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public IList<Unit> Units;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="units"></param>
        public FoodUnitsReceivedEventArgs(IList<Unit> units)
        {
            this.Units = units;
        }
    }
}
