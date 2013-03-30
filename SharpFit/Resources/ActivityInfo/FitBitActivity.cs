// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using SharpFit.OAuth;

namespace SharpFit.Resources.ActivityInfo
{

    public class FitBitActivity
    {
        /// <summary>
        /// List of Acetivity
        /// </summary>
        [JsonProperty("activities")]
        public IList<Activity> Activities { get; set; }

        /// <summary>
        /// User created goals
        /// </summary>
        [JsonProperty("goals")]
        public Goals Goals { get; set; }

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
            request = new RestRequest(String.Format("/user/-/activities/date/{0}-{1}-{2}.json", date.Year, date.Month, date.Day));
            request.AddParameter("Accept_Locale", "en_US");
            client.ExecuteAsync(request, response =>
            {
                FitBitActivity p = new FitBitActivity();
                p = JsonConvert.DeserializeObject<FitBitActivity>(response.Content);
                NotifyComplete(p);
            });
        }

        /// <summary>
        /// Event Handler for retrieving user activities
        /// </summary>
        /// <param name="sender">The object triggering the event</param>
        /// <param name="e">The results of the event</param>
        public delegate void ActivitiesReceivedHandler(object sender, ActivitiesReceivedEventArgs e);

        /// <summary>
        /// Event occurring when the downloading of events has completed
        /// </summary>
        public event ActivitiesReceivedHandler ActivitiesCompleted;

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
    }

    /// <summary>
    /// 
    /// </summary>
    public class ActivitiesReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public FitBitActivity Activities;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activities"></param>
        public ActivitiesReceivedEventArgs(FitBitActivity activities)
        {
            Activities = activities;
        }
    }
}
