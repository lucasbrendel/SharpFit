using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using SharpFit.OAuth;
using SharpFit.Events;

namespace SharpFit.Resources.ActivityInfo
{

    public class FitBitActivity
    {
        /// <summary>
        /// List of Activity
        /// </summary>
        [JsonProperty("activities")]
        public IList<Activity> Activities { get; set; }

        /// <summary>
        /// User created goals
        /// </summary>
        [JsonProperty("goals")]
        public DailyGoals Goals { get; set; }

        /// <summary>
        /// Summary of goals for the current day
        /// </summary>
        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        public void GetActivities(DateTime date)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest(String.Format("/user/-/activities/date/{0}-{1}-{2}.json", date.Year, date.Month, date.Day), Method.GET);
            request.AddParameter("Accept_Locale", "en_US");
            client.ExecuteAsync(request, response =>
            {
                FitBitActivity p = new FitBitActivity();
                p = JsonConvert.DeserializeObject<FitBitActivity>(response.Content);
                NotifyComplete(p);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetDailyGoals()
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/user/-/activities/goals/daily.json", Method.GET);
            request.AddParameter("Accept_Locale", "en_US");
            client.ExecuteAsync(request, response =>
            {
                FitBitActivity p = new FitBitActivity();
                p = JsonConvert.DeserializeObject<FitBitActivity>(response.Content);
                NotifyDailyGoalsReceived(p);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetWeeklyGoals()
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/user/-/activities/goals/weekly.json", Method.GET);
            request.AddParameter("Accept_Locale", "en_US");
            client.ExecuteAsync(request, response =>
            {
                FitBitActivity p = new FitBitActivity();
                p = JsonConvert.DeserializeObject<FitBitActivity>(response.Content);
                NotifyDailyGoalsReceived(p);
            });
        }

        /// <summary>
        /// Event Handler for retrieving user activities
        /// </summary>
        /// <param name="sender">The object triggering the event</param>
        /// <param name="e">The results of the event</param>
        public delegate void ActivitiesReceivedHandler(object sender, ActivitiesReceivedEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ActivitiesDailyGoalsReceivedEventHandler(object sender, ActivitiesDailyGoalsReceivedEventArgs e);

        /// <summary>
        /// Event occurring when the downloading of events has completed
        /// </summary>
        public event ActivitiesReceivedHandler ActivitiesCompleted;

        /// <summary>
        /// 
        /// </summary>
        public event ActivitiesDailyGoalsReceivedEventHandler ActivitiesDailyGoalsReceived;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activity"></param>
        private void NotifyComplete(FitBitActivity activity)
        {
            if (ActivitiesCompleted != null)
            {
                ActivitiesCompleted(this, new ActivitiesReceivedEventArgs(activity));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        private void NotifyDailyGoalsReceived(FitBitActivity p)
        {
            if (ActivitiesDailyGoalsReceived != null)
            {
                ActivitiesDailyGoalsReceived(this, new ActivitiesDailyGoalsReceivedEventArgs(p.Goals));
            }
        }
    }
}
