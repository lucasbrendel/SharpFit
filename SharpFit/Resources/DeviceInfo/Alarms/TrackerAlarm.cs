using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.DeviceInfo.Alarms
{

    public class TrackerAlarm
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("alarmId")]
        public int AlarmId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("recurring")]
        public bool Recurring { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("snoozeCount")]
        public int SnoozeCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("snoozeLength")]
        public int SnoozeLength { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("syncedToDevice")]
        public bool SyncedToDevice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("time")]
        public string Time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("vibe")]
        public string Vibe { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("weekDays")]
        public string[] WeekDays { get; set; }
    }

}
