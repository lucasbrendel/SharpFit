using SharpFit.Resources.FoodInfo.WaterInfo;
using System;

namespace SharpFit.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class LogWaterEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public WaterLog water;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="water"></param>
        public LogWaterEventArgs(WaterLog water)
        {
            this.water = water;
        }
    }
}
