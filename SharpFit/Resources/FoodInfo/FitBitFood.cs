﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using SharpFit.Events;
using SharpFit.OAuth;

namespace SharpFit.Resources.FoodInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class FitBitFood
    {
        public delegate void FoodReceivedEventHandler(object sender, FoodGetEventArgs e);

        public delegate void FoodGoalReceivedEventHandler(object sender, FoodGoalsGetEventArgs e);

        public event FoodReceivedEventHandler FoodReceived;

        public event FoodGoalReceivedEventHandler FoodGoalReceived;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("foods")]
        public IList<Food> Foods { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("goals")]
        public Goals Goals { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        public void GetFoods(DateTime date)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest(String.Format("/user/-/foods/log/date/{0}-{1}-{2}.json", date.Year, date.Month, date.Day), Method.GET);
            request.AddHeader("Accept-Language", "en_US");
            client.ExecuteAsync(request, response =>
            {
                FitBitFood food = new FitBitFood();
                food = JsonConvert.DeserializeObject<FitBitFood>(response.Content);
                NotifyReceived(food);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetFoodGoals()
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/user/-/foods/log/goal.json", Method.GET);
            request.AddHeader("Accept-Language", "en_US");
            client.ExecuteAsync(request, response =>
            {
                Goals food = new Goals();
                food = JsonConvert.DeserializeObject<Goals>(response.Content);
                NotifyGoalReceived(food);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="food"></param>
        private void NotifyGoalReceived(FoodInfo.Goals food)
        {
            if (FoodGoalReceived != null)
            {
                FoodGoalReceived(this, new FoodGoalsGetEventArgs(food));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="food"></param>
        private void NotifyReceived(FitBitFood food)
        {
            if (FoodReceived != null)
            {
                FoodReceived(this, new FoodGetEventArgs(food));
            }
        }
    }
}
