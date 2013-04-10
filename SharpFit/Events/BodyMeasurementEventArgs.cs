using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpFit.Resources.BodyInfo.Measurements;

namespace SharpFit.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class BodyMeasurementsEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public FitBitBody Measurements;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="measurements"></param>
        public BodyMeasurementsEventArgs(FitBitBody measurements)
        {
            this.Measurements = measurements;
        }
    }
}
