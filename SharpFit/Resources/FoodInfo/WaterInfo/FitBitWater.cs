// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using SharpFit.Events;
using SharpFit.OAuth;
using System;
using System.Collections.Generic;
using SharpFit.Exceptions;

namespace SharpFit.Resources.FoodInfo.WaterInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class FitBitWater
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("water")]
        public IList<Water> Water { get; set; }

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
            if (param.ContainsKey("date") && param.ContainsKey("amount"))
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
            else
            {
                if (!param.ContainsKey("date"))
                {
                    throw new MissingParameterException("date");
                }
                if (!param.ContainsKey("amount"))
                {
                    throw new MissingParameterException("amount");
                }
            }
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
                string state = response.StatusCode.ToString();
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
}
