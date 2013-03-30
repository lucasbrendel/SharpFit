using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpFit.Resources.FoodInfo;
using Newtonsoft.Json;

namespace SharpFit.General.Search
{
    public class FoodSearch
    {
        [JsonProperty("foods")]
        public IList<LoggedFood> foods;
    }
}
