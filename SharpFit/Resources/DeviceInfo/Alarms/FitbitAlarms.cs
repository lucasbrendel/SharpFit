using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharpFit.Events;
using SharpFit.OAuth;
using RestSharp;
using RestSharp.Authenticators;

namespace SharpFit.Resources.DeviceInfo.Alarms
{

    public class FitbitAlarms
    {
        public delegate void AlarmsReceivedEventHandler(object sender, DeviceAlarmsEventArgs e);

        public event AlarmsReceivedEventHandler AlarmsReceived;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("trackerAlarms")]
        public IList<TrackerAlarm> TrackerAlarms { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FitbitAlarms()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alarms"></param>
        public FitbitAlarms(IList<TrackerAlarm> alarms)
        {
            this.TrackerAlarms = alarms;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceID"></param>
        public void GetTrackerAlarms(int deviceID)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/user/-/devices/tracker/" + deviceID.ToString() + "/alarms.json", Method.GET);
            client.ExecuteAsync(request, response =>
            {
                FitbitAlarms a = new FitbitAlarms();
                a = JsonConvert.DeserializeObject<FitbitAlarms>(response.Content);
                NotifyReceived(a);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        public void GetTrackerAlarms(Device device)
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/user/-/devices/tracker/" + device.ID + "/alarms.json", Method.GET);
            client.ExecuteAsync(request, response =>
            {
                FitbitAlarms a = new FitbitAlarms();
                a = JsonConvert.DeserializeObject<FitbitAlarms>(response.Content);
                NotifyReceived(a);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        private void NotifyReceived(FitbitAlarms a)
        {
            if (AlarmsReceived != null)
            {
                AlarmsReceived(this, new DeviceAlarmsEventArgs(a));
            }
        }
    }

}
