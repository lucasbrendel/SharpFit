using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpFit.Resources.GlucoseInfo;

namespace SharpFit.Events
{
    public class GlucoseGetEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public FitBitGlucose Glucose;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="glucose"></param>
        public GlucoseGetEventArgs(FitBitGlucose glucose)
        {
            this.Glucose = glucose;
        }
    }
}
