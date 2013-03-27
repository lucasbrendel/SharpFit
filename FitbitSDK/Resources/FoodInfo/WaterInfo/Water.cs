// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using FitbitSDK.OAuth;

namespace FitbitSDK.Resources.FoodInfo.WaterInfo
{

    public class Water
    {

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("logId")]
        public int LogId { get; set; }
        

        public Water()
        {

        }

        public void GetWater(DateTime date)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest(String.Format("/user/-/foods/log/water/date/{0}-{1}-{2}.json", date.Year, date.Month, date.Day), Method.GET);
            request.AddHeader("Accept-Language", "en_US");
            client.ExecuteAsync(request, response =>
                {
                    FitBitWater water = new FitBitWater();
                    water = JsonConvert.DeserializeObject<FitBitWater>(response.Content);
                    NotifyDownloaded(water);
                });
        }

        public void LogWater(Dictionary<string, string> param)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/user/-/foods/log/water.json", Method.POST);
            foreach (KeyValuePair<string, string> p in param)
            {
                request.AddParameter(p.Key, p.Value);
            }

            client.ExecuteAsync(request, response =>
                {
                    WaterLog w = new WaterLog();
                    w = JsonConvert.DeserializeObject<WaterLog>(response.Content);
                    NotifyComplete(w);
                });
        }

        public void DeleteWater(string ID)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/user/-/foods/log/water/" + ID + ".json", Method.DELETE);
            client.ExecuteAsync(request, response =>
            {

            });
        }

        public delegate void WaterLoggedHandler(object sender, LogWaterEventArgs e);
        public delegate void WaterSummaryGetHandler(object sender, WaterSummaryEventArgs e);

        public event WaterLoggedHandler WaterLogged;
        public event WaterSummaryGetHandler WaterSummaryDownloaded;

        public void NotifyDownloaded(FitBitWater summary)
        {
            if (WaterSummaryDownloaded != null)
            {
                WaterSummaryDownloaded(this, new WaterSummaryEventArgs(summary));
            }
        }

        public void NotifyComplete(WaterLog water)
        {
            if (WaterLogged != null)
            {
                WaterLogged(this, new LogWaterEventArgs(water));
            }
        }
    }

    public class LogWaterEventArgs : EventArgs
    {
        public WaterLog water;

        public LogWaterEventArgs(WaterLog water)
        {
            this.water = water;
        }
    }

    public class WaterSummaryEventArgs : EventArgs
    {
        public FitBitWater WaterSummary;

        public WaterSummaryEventArgs(FitBitWater summary)
        {
            WaterSummary = summary;
        }
    }
}
