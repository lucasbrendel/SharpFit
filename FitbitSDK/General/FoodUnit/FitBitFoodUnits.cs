// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using FitbitSDK.OAuth;

namespace FitbitSDK.General.FoodUnit
{

    public class FitBitFoodUnits
    {

        [JsonProperty("units")]
        public IList<Unit> Units { get; set; }

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

        public delegate void FoodUnitsReceivedEventHander(object sender, FoodUnitsReceivedEventArgs e);

        public event FoodUnitsReceivedEventHander FoodUnitsReceived;

        public void NotifyReceived(IList<Unit> units)
        {
            if (FoodUnitsReceived != null)
            {
                FoodUnitsReceived(this, new FoodUnitsReceivedEventArgs(units));
            }
        }
    }

    public class FoodUnitsReceivedEventArgs : EventArgs
    {
        public IList<Unit> Units;

        public FoodUnitsReceivedEventArgs(IList<Unit> units)
        {
            this.Units = units;
        }
    }
}
