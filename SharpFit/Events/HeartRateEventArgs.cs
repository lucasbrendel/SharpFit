using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpFit.Resources.HeartRateInfo;

namespace SharpFit.Events
{
    public class HeartRateEventArgs :EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public FitBitHeartRate heart;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="heart"></param>
        public HeartRateEventArgs(FitBitHeartRate heart)
        {
            this.heart = heart;
        }
    }
}
