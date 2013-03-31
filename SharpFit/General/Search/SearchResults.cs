using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpFit.Resources.FoodInfo;
using Newtonsoft.Json;

namespace SharpFit.General.Search
{
    /// <summary>
    /// 
    /// </summary>
    public class FoodSearch
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("foods")]
        public IList<LoggedFood> foods;
    }
}
