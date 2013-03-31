// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.FoodInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class LoggedFood
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("accessLevel")]
        public string AccessLevel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("amount")]
        public double Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("brand")]
        public string Brand { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("calories")]
        public int Calories { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("foodId")]
        public int FoodId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mealTypeId")]
        public int MealTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("unit")]
        public Unit Unit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("units")]
        public IList<int> Units { get; set; }
    }
}
