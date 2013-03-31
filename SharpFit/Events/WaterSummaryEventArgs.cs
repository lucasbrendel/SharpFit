using SharpFit.Resources.FoodInfo.WaterInfo;
using System;

namespace SharpFit.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class WaterSummaryEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public FitBitWater WaterSummary;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="summary"></param>
        public WaterSummaryEventArgs(FitBitWater summary)
        {
            WaterSummary = summary;
        }
    }
}
