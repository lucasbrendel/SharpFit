using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpFit.Resources.ActivityInfo;

namespace SharpFit.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class ActivitiesReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public FitBitActivity Activities;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activities"></param>
        public ActivitiesReceivedEventArgs(FitBitActivity activities)
        {
            Activities = activities;
        }
    }
}
