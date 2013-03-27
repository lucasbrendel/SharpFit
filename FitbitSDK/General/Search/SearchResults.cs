using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FitbitSDK.Resources.FoodInfo;
using Newtonsoft.Json;

namespace FitbitSDK.General.Search
{
    public class FoodSearch
    {
        [JsonProperty("foods")]
        public IList<LoggedFood> foods;
    }
}
