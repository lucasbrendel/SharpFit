using SharpFit.Resources.FoodInfo.WaterInfo;
using System;

namespace SharpFit.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class WaterGetEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public FitBitWater WaterSummary;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="summary"></param>
        public WaterGetEventArgs(FitBitWater summary)
        {
            WaterSummary = summary;
        }
    }

    public class WaterDeletedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isDeleted"></param>
        public WaterDeletedEventArgs(bool isDeleted)
        {
            this.IsDeleted = isDeleted;
        }
    }

    public class WaterLoggedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public WaterLog water;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="water"></param>
        public WaterLoggedEventArgs(WaterLog water)
        {
            this.water = water;
        }
    }
}
