using Newtonsoft.Json;

namespace SharpFit.Resources.ActivityInfo
{
    /// <summary>
    /// Json deserializable class for an activity
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// The unique ID of the activity
        /// </summary>
        [JsonProperty("activityId")]
        public int ActivityId { get; set; }

        /// <summary>
        /// Unique ID of the parent activity
        /// </summary>
        [JsonProperty("activityParentId")]
        public int ActivityParentId { get; set; }

        /// <summary>
        /// Calories burned during activity
        /// </summary>
        [JsonProperty("calories")]
        public int Calories { get; set; }

        /// <summary>
        /// Descriptive information of the activity
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Distance traveled doing the activity
        /// </summary>
        [JsonProperty("distance")]
        public double Distance { get; set; }

        /// <summary>
        /// Length of time of the activity
        /// </summary>
        [JsonProperty("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// Notifies if a start time was recorded
        /// </summary>
        [JsonProperty("hasStartTime")]
        public bool HasStartTime { get; set; }

        /// <summary>
        /// Favorite activity or not
        /// </summary>
        [JsonProperty("isFavorite")]
        public bool IsFavorite { get; set; }

        /// <summary>
        /// Unique ID of the activity when it was logged
        /// </summary>
        [JsonProperty("logId")]
        public int LogId { get; set; }

        /// <summary>
        /// Name of the activity
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// String representation of the start time of the activity
        /// </summary>
        [JsonProperty("startTime")]
        public string StartTime { get; set; }

        /// <summary>
        /// Number of steps taken
        /// </summary>
        [JsonProperty("steps")]
        public int Steps { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Activity()
        {

        }

    }
}
