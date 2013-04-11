using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharpFit.Events;
using RestSharp;
using RestSharp.Authenticators;
using SharpFit.OAuth;

namespace SharpFit.Resources.BodyInfo.Weight
{

    public class FitbitWeightGoal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void WeightGoalReceivedEventHandler(object sender, BodyWeightGoalEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        public event WeightGoalReceivedEventHandler BodyWeightGoalReceived;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("goal")]
        public WeightGoal Goal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FitbitWeightGoal()
        {
            Goal = new WeightGoal();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goal"></param>
        public FitbitWeightGoal(WeightGoal goal)
        {
            this.Goal = goal;
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetWeightGoal()
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/user/-/body/log/weight/goal.json", Method.GET);
            client.ExecuteAsync(request, response =>
            {
                FitbitWeightGoal w = new FitbitWeightGoal();
                w = JsonConvert.DeserializeObject<FitbitWeightGoal>(response.Content);
                NotifyReceived(w);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="w"></param>
        private void NotifyReceived(FitbitWeightGoal w)
        {
            if (BodyWeightGoalReceived != null)
            {
                BodyWeightGoalReceived(this, new BodyWeightGoalEventArgs(w));
            }
        }
    }

}
