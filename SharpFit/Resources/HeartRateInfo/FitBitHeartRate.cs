// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using SharpFit.OAuth;
using SharpFit.Events;
using SharpFit.Exceptions;

namespace SharpFit.Resources.HeartRateInfo
{
    public class FitBitHeartRate
    {
        public delegate void HeartRateLogHandler(object sender, HeartRateLoggedEventArgs e);
        public delegate void HeartRateGetHandler(object sender, HeartRateEventArgs e);
        public delegate void HeartRateDeleteHandler(object sender, HeartRateDeletedEventArgs e);

        public event HeartRateLogHandler HeartRateLogged;
        public event HeartRateGetHandler HeartRateReceived;
        public event HeartRateDeleteHandler HeartRateDeleted;

        /// <summary>
        /// List of Average heart rates
        /// </summary>
        [JsonProperty("average")]
        public IList<Average> Average { get; set; }

        /// <summary>
        /// List of heart logs
        /// </summary>
        [JsonProperty("heart")]
        public IList<Heart> Heart { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public FitBitHeartRate()
        {
            this.Average = null;
            this.Heart = null;
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="averages">Averages for each tracker for the day</param>
        /// <param name="heartLogs">All logs for a specific day</param>
        public FitBitHeartRate(IList<Average> averages, IList<Heart> heartLogs)
        {
            this.Average = averages;
            this.Heart = heartLogs;
        }

        /// <summary>
        /// Get the users heart rates from a specific date
        /// </summary>
        /// <param name="date">The day of heart rates to get</param>
        public void GetHeartRate(DateTime date)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest(String.Format("/user/-/heart/date/{0}-{1}-{2}.json", date.Year, date.Month, date.Day), Method.GET);
            request.AddHeader("Accept-Language", "en_US");
            client.ExecuteAsync(request, response =>
                {
                    FitBitHeartRate heart = new FitBitHeartRate();
                    heart = JsonConvert.DeserializeObject<FitBitHeartRate>(response.Content);
                    NotifyDownloaded(heart);
                });
        }

        /// <summary>
        /// Creates a new logged heart rate
        /// </summary>
        /// <param name="parameters">string of parameters</param>
        /// <remarks>Parameters tracker, heartRate, and date are required, time is optional</remarks>
        public void LogHeartRate(Dictionary<string, string> parameters)
        {
            if (parameters.ContainsKey("date") && parameters.ContainsKey("heartRate") && parameters.ContainsKey("tracker"))
            {
                RestRequest request;
                var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
                client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
                request = new RestRequest("/user/-/heart.json", Method.POST);
                foreach (KeyValuePair<string, string> p in parameters)
                {
                    request.AddParameter(p.Key, p.Value);
                }

                client.ExecuteAsync(request, response =>
                    {
                        Heart heartlog = new Heart();
                        heartlog = JsonConvert.DeserializeObject<Heart>(response.Content);
                        NotifyLogged(heartlog);
                    });
            }
            else
            {
                if (!parameters.ContainsKey("date"))
                {
                    throw new MissingParameterException("date");
                }
                else if (!parameters.ContainsKey("tracker"))
                {
                    throw new MissingParameterException("tracker");
                }
                else if (!parameters.ContainsKey("heartRate"))
                {
                    throw new MissingParameterException("heartRate");
                }
            }
        }

        /// <summary>
        /// Creates a new logged heart rate
        /// </summary>
        /// <param name="date">date of logged heart rate</param>
        /// <param name="tracker">specific heart tracker to place the log under</param>
        /// <param name="heartRate">Heart rate</param>
        public void LogHeartRate(DateTime date, string tracker, int heartRate)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/user/-/heart.json", Method.POST);
            request.AddParameter("tracker", tracker);
            request.AddParameter("date", String.Format("{0}-{1}-{2}", date.Year, date.Month, date.Day));
            request.AddParameter("heartRate", heartRate.ToString());

            client.ExecuteAsync(request, response =>
            {
                Heart heartlog = new Heart();
                heartlog = JsonConvert.DeserializeObject<Heart>(response.Content);
                NotifyLogged(heartlog);
            });
        }

        /// <summary>
        /// Creates a new logged heart rate
        /// </summary>
        /// <param name="date">date of logged heart rate</param>
        /// <param name="tracker">specific heart tracker to place the log under</param>
        /// <param name="heartRate">Heart rate</param>
        /// <param name="time">Time of logging</param>
        public void LogHeartRate(DateTime date, string tracker, int heartRate, DateTime time)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/user/-/heart.json", Method.POST);
            request.AddParameter("tracker", tracker);
            request.AddParameter("date", String.Format("{0}-{1}-{2}", date.Year, date.Month, date.Day));
            request.AddParameter("heartRate", heartRate.ToString());
            request.AddParameter("time", String.Format("{0}:{1}", time.Hour, time.Minute));

            client.ExecuteAsync(request, response =>
            {
                Heart heartlog = new Heart();
                heartlog = JsonConvert.DeserializeObject<Heart>(response.Content);
                NotifyLogged(heartlog);
            });
        }

        /// <summary>
        /// Creates a new logged heart rate
        /// </summary>
        /// <param name="date">date of logged heart rate</param>
        /// <param name="heartInfo">hreat rate information to log</param>
        public void LogHeartRate(DateTime date, Heart heartInfo)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/user/-/heart.json", Method.POST);
            request.AddParameter("tracker", heartInfo.Tracker);
            request.AddParameter("date", String.Format("{0}-{1}-{2}", date.Year, date.Month, date.Day));
            request.AddParameter("heartRate", heartInfo.HeartRate.ToString());
            request.AddParameter("time", heartInfo.Time);

            client.ExecuteAsync(request, response =>
            {
                Heart heartlog = new Heart();
                heartlog = JsonConvert.DeserializeObject<Heart>(response.Content);
                NotifyLogged(heartlog);
            });
        }

        /// <summary>
        /// Deletes a logged heart rate
        /// </summary>
        /// <param name="logId">Unique ID of a logged heart rate to delete</param>
        public void DeleteHeartRate(int logId)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/user/-/heart/" + logId.ToString() + ".json");
            client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
                    {
                        NotifyDeleted(true);
                    }
                    else
                    {
                        NotifyDeleted(false);
                    }
                    
                });
        }

        /// <summary>
        /// Event trigger when a heart rate log has been deleted
        /// </summary>
        /// <param name="isDeleted">Notifier if the heart rate was deleted</param>
        private void NotifyDeleted(bool isDeleted)
        {
            if (HeartRateDeleted != null)
            {
                HeartRateDeleted(this, new HeartRateDeletedEventArgs(isDeleted));
            }
        }

        /// <summary>
        /// Event trigger when all heart logs for a specific day have been downloaded
        /// </summary>
        /// <param name="heartRate">Heart rate listings for a specific day</param>
        private void NotifyDownloaded(FitBitHeartRate heartRate)
        {
            if (HeartRateReceived != null)
            {
                HeartRateReceived(this, new HeartRateEventArgs(heartRate));
            }
        }

        /// <summary>
        /// Event trigger when a new heart rate has been logged
        /// </summary>
        /// <param name="heartlog">Newly created heart log</param>
        private void NotifyLogged(Heart heartlog)
        {
            if (HeartRateLogged != null)
            {
                HeartRateLogged(this, new HeartRateLoggedEventArgs(heartlog));
            }
        }
    }
}
