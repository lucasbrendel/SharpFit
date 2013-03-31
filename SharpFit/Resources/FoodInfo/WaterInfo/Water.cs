// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using Newtonsoft.Json;

namespace SharpFit.Resources.FoodInfo.WaterInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class Water
    {
        /// <summary>
        /// Amount of water logged
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Unique identification for a logged event of water
        /// </summary>
        [JsonProperty("logId")]
        public int LogId { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Water()
        {
            Amount = 0;
            LogId = 0;
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="amount">Amount of water to log</param>
        /// <param name="id">Uniqu ID of logged event</param>
        public Water(int amount, int id)
        {
            Amount = amount;
            LogId = id;
        }
    }
}
