using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharpFit.Events;
using SharpFit.OAuth;
using RestSharp;
using RestSharp.Authenticators;

namespace SharpFit.Resources.BodyInfo.Fat
{

    public class FitbitFatGoal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void BodyFatGoalReceivedEventHandler(object sender, BodyFatGoalReceivedEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        public event BodyFatGoalReceivedEventHandler BodyFatGoalReceived;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("goal")]
        public FatGoal Goal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FitbitFatGoal()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goal"></param>
        public FitbitFatGoal(FatGoal goal)
        {
            this.Goal = goal;
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetFatGoal()
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/user/-/body/log/fat/goal.json", Method.GET);
            client.ExecuteAsync(request, response =>
            {
                FitbitFatGoal g = new FitbitFatGoal();
                g = JsonConvert.DeserializeObject<FitbitFatGoal>(response.Content);
                NotifyReceived(g);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goal"></param>
        private void NotifyReceived(FitbitFatGoal goal)
        {
            if (BodyFatGoalReceived != null)
            {
                BodyFatGoalReceived(this, new BodyFatGoalReceivedEventArgs(goal));
            }
        }
    }

}
