﻿// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using SharpFit.OAuth;

namespace SharpFit.Resources.FoodInfo.WaterInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class Water
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("logId")]
        public int LogId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public Water()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void WaterLoggedHandler(object sender, LogWaterEventArgs e);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void WaterSummaryGetHandler(object sender, WaterSummaryEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        public event WaterLoggedHandler WaterLogged;
        
        /// <summary>
        /// 
        /// </summary>
        public event WaterSummaryGetHandler WaterSummaryDownloaded;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="summary"></param>
        public void NotifyDownloaded(FitBitWater summary)
        {
            if (WaterSummaryDownloaded != null)
            {
                WaterSummaryDownloaded(this, new WaterSummaryEventArgs(summary));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="water"></param>
        public void NotifyComplete(WaterLog water)
        {
            if (WaterLogged != null)
            {
                WaterLogged(this, new LogWaterEventArgs(water));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class LogWaterEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public WaterLog water;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="water"></param>
        public LogWaterEventArgs(WaterLog water)
        {
            this.water = water;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class WaterSummaryEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public FitBitWater WaterSummary;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="summary"></param>
        public WaterSummaryEventArgs(FitBitWater summary)
        {
            WaterSummary = summary;
        }
    }
}
