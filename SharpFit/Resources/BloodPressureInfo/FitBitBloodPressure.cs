using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using SharpFit.OAuth;
using SharpFit.Events;
using SharpFit.Exceptions;

namespace SharpFit.Resources.BloodPressureInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class FitBitBloodPressure
    {
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

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="avg"></param>
        /// <param name="pressure"></param>
        public FitBitBloodPressure(Average avg, Bp pressure)
        {

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

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logID"></param>
        public void DeleteBloodPressure(int logID)
        {

        }
    }
}
