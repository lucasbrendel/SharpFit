using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpFit.Resources.SleepInfo;

namespace SharpFit.Events
{
    public class SleepGetEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public FitBitSleep Sleep;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sleep"></param>
        public SleepGetEventArgs(FitBitSleep sleep)
        {
            this.Sleep = sleep;
        }
    }
}
