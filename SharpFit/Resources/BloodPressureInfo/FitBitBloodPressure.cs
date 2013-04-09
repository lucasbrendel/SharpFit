using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using SharpFit.OAuth;
using SharpFit.Events;
using SharpFit.Exceptions;
using SharpFit;

namespace SharpFit.Resources.BloodPressureInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class FitBitBloodPressure
    {
        public delegate void BloodPressureGotHandler(object sender, BloodPressureGetEventArgs e);
        public delegate void BloodPressureLoggedHandler(object sender, BloodPressureLoggedEventArgs e);
        public delegate void BloodPressureDeletedHandler(object sender, BloodPressureDeletedEventArgs e);

        public event BloodPressureGotHandler BloodPressureReceived;
        public event BloodPressureLoggedHandler BloodPressureLogged;
        public event BloodPressureDeletedHandler BloodPressureDeleted;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("average")]
        public Average Average { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bp")]
        public IList<Bp> Bp { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public FitBitBloodPressure()
        {
            this.Average = null;
            this.Bp = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="avg"></param>
        /// <param name="pressure"></param>
        public FitBitBloodPressure(Average avg, IList<Bp> pressure)
        {
            this.Average = avg;
            this.Bp = pressure;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        public void GetBloodPressure(DateTime date)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest(String.Format("/1/user/-/bp/date/{0}-{1}-{2}.json", date.Year, date.Month, date.Day), Method.GET);
            request.AddHeader("Accept-Language", "en_US");
            client.ExecuteAsync(request, response =>
                {
                    FitBitBloodPressure bloodPressure = new FitBitBloodPressure();
                    bloodPressure = JsonConvert.DeserializeObject<FitBitBloodPressure>(response.Content);
                    NotifyReceived(bloodPressure);
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        public void LogBloodPressure(Dictionary<string, string> parameters)
        {
            if (parameters.ContainsKey("systolic") && parameters.ContainsKey("diastolic") && parameters.ContainsKey("date"))
            {
                RestRequest request;
                var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
                client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
                request = new RestRequest("/1/user/-/bp.json", Method.POST);
                foreach (KeyValuePair<string, string> p in parameters)
                {
                    if (p.Key == "date" && APIAccess.IsValidDate(p.Value))
                    {
                        throw new FormatException("Request parameter 'date' was not in the correct format YYYY-MM-DD.");
                    }
                    else
                    {
                        request.AddParameter(p.Key, p.Value);
                    }
                }
                request.AddHeader("Accept-Language", "en_US");
                client.ExecuteAsync(request, response =>
                {
                    Bp bp = new Bp();
                    bp = JsonConvert.DeserializeObject<Bp>(response.Content);
                    NotifyLogged(bp);
                });
            }
            else
            {
                if (!parameters.ContainsKey("systolic"))
                {
                    throw new MissingParameterException("systolic");
                }
                if (!parameters.ContainsKey("diastolic"))
                {
                    throw new MissingParameterException("diastolic");
                }
                if (!parameters.ContainsKey("date"))
                {
                    throw new MissingParameterException("date");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Systolic"></param>
        /// <param name="Diastolic"></param>
        /// <param name="date"></param>
        public void LogBloodPressure(int Systolic, int Diastolic, DateTime date)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/1/user/-/bp.json", Method.POST);
            request.AddParameter("systolic", Systolic);
            request.AddParameter("systolic", Diastolic);
            request.AddParameter("date", String.Format("{0}-{1}-{2}", date.Year, date.Month, date.Day));
            request.AddHeader("Accept-Language", "en_US");
            client.ExecuteAsync(request, response =>
            {
                Bp bp = new Bp();
                bp = JsonConvert.DeserializeObject<Bp>(response.Content);
                NotifyLogged(bp);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="systolic"></param>
        /// <param name="diastolic"></param>
        /// <param name="date"></param>
        /// <param name="time">OPTIONAL parameter for the time of measurement</param>
        public void LogBloodPressure(int systolic, int diastolic, DateTime date, DateTime time)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/1/user/-/bp.json", Method.POST);
            request.AddParameter("systolic", systolic);
            request.AddParameter("systolic", diastolic);
            request.AddParameter("date", String.Format("{0}-{1}-{2}", date.Year, date.Month, date.Day));
            request.AddParameter("time", String.Format("{0}:{1}", time.Hour, time.Minute));
            request.AddHeader("Accept-Language", "en_US");
            client.ExecuteAsync(request, response =>
            {
                Bp bp = new Bp();
                bp = JsonConvert.DeserializeObject<Bp>(response.Content);
                NotifyLogged(bp);
            });

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logID"></param>
        public void DeleteBloodPressure(int logID)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bloodPressure"></param>
        private void NotifyReceived(FitBitBloodPressure bloodPressure)
        {
            if (BloodPressureReceived != null)
            {
                BloodPressureReceived(this, new BloodPressureGetEventArgs(bloodPressure));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bp"></param>
        private void NotifyLogged(BloodPressureInfo.Bp bp)
        {
            if (BloodPressureLogged != null)
            {
                BloodPressureLogged(this, new BloodPressureLoggedEventArgs(bp));
            }
        }
    }
}
