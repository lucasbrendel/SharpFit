using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharpFit.Resources.BodyInfo.Fat
{

    public class FatGoal
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("fat")]
        public int Fat { get; set; }
    }

}
