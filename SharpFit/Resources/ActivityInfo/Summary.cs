// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.ActivityInfo
{

    public class Summary
    {

        [JsonProperty("activeScore")]
        public int ActiveScore { get; set; }

        [JsonProperty("activityCalories")]
        public int ActivityCalories { get; set; }

        [JsonProperty("caloriesOut")]
        public int CaloriesOut { get; set; }

        [JsonProperty("distances")]
        public IList<Distances> Distances { get; set; }

        [JsonProperty("elevation")]
        public double Elevation { get; set; }

        [JsonProperty("fairlyActiveMinutes")]
        public int FairlyActiveMinutes { get; set; }

        [JsonProperty("floors")]
        public int Floors { get; set; }

        [JsonProperty("lightlyActiveMinutes")]
        public int LightlyActiveMinutes { get; set; }

        [JsonProperty("marginalCalories")]
        public int MarginalCalories { get; set; }

        [JsonProperty("sedentaryMinutes")]
        public int SedentaryMinutes { get; set; }

        [JsonProperty("steps")]
        public int Steps { get; set; }

        [JsonProperty("veryActiveMinutes")]
        public int VeryActiveMinutes { get; set; }
    }
}
