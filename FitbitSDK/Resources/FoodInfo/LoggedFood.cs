// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FitbitSDK.Resources.FoodInfo
{

    public class LoggedFood
    {

        [JsonProperty("accessLevel")]
        public string AccessLevel { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("calories")]
        public int Calories { get; set; }

        [JsonProperty("foodId")]
        public int FoodId { get; set; }

        [JsonProperty("mealTypeId")]
        public int MealTypeId { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("unit")]
        public Unit Unit { get; set; }

        [JsonProperty("units")]
        public IList<int> Units { get; set; }
    }
}
