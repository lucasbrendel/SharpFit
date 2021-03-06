﻿// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.BodyInfo.Weight
{
    /// <summary>
    /// 
    /// </summary>
    public class Weight
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bmi")]
        public double Bmi { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("date")]
        public string Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("logId")]
        public object LogId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("time")]
        public string Time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("weight")]
        public double Weights { get; set; }
    }
}
