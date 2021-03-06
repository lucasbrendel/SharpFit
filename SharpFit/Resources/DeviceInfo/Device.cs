﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using System.ComponentModel;
using SharpFit.OAuth;

namespace SharpFit.Resources.DeviceInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class Device : INotifyPropertyChanged
    {
        private string _battery;
        private string _id;
        private DateTime _lastSyncTime;
        private DeviceType _type;
        private DeviceVersions _deviceVersion;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName="battery")]
        public string Battery
        {
            get { return _battery; }
            set
            {
                if (value != _battery)
                {
                    _battery = value;
                    NotifyChanged("Battery");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName="id")]
        public string ID
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyChanged("ID");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName="lastSyncTime")]
        public DateTime LastSyncTime
        {
            get { return _lastSyncTime; }
            set
            {
                if (value != _lastSyncTime)
                {
                    _lastSyncTime = value;
                    NotifyChanged("LastSyncTime");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName="type")]
        public DeviceType Type
        {
            get { return _type; }
            set
            {
                if (value != _type)
                {
                    _type = value;
                    NotifyChanged("Type");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName="deviceVersion")]
        public DeviceVersions DeviceVersion
        {
            get { return _deviceVersion; }
            set
            {
                if (value != _deviceVersion)
                {
                    _deviceVersion = value;
                    NotifyChanged("DeviceVersion");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public enum DeviceVersions
        {
            Classic,
            Ultra,
            Aria
        }

        /// <summary>
        /// 
        /// </summary>
        public enum DeviceType
        {
            TRACKER,
            SCALE
        }

        /// <summary>
        /// 
        /// </summary>
        public Device()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void GetDevices()
        {
            RestRequest request;
            var client = new RestClient(OAuthCredentials.APIAccessStringWithVersion);
            client.Authenticator = OAuth1Authenticator.ForProtectedResource(OAuthCredentials.ConsumerKey, OAuthCredentials.ConsumerSecret, OAuthCredentials.AccessToken, OAuthCredentials.AccessTokenSecret);
            request = new RestRequest("/user/-/devices.json");
            client.ExecuteAsync(request, response =>
                {
                    IList<Device> d = new List<Device>();
                    d = JsonConvert.DeserializeObject<List<Device>>(response.Content);
                    NotifyDownloadComplete(d);
                });
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public delegate void DeviceDownloadCompleteEventHandler(object sender, DeviceDownloadEventArgs e);

        public event DeviceDownloadCompleteEventHandler DevicesDownloaded;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        public void NotifyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="devices"></param>
        public void NotifyDownloadComplete(IList<Device> devices)
        {
            if (DevicesDownloaded != null)
            {
                DevicesDownloaded(this, new DeviceDownloadEventArgs(devices));
            }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class DeviceDownloadEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public IList<Device> DeviceList
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceList"></param>
        public DeviceDownloadEventArgs(IList<Device> deviceList)
        {
            DeviceList = deviceList;
        }
    }
}
