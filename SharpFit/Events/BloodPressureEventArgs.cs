using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpFit.Resources.BloodPressureInfo;

namespace SharpFit.Events
{
    public class BloodPressureGetEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public FitBitBloodPressure BP;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bp"></param>
        public BloodPressureGetEventArgs(FitBitBloodPressure bp)
        {
            this.BP = bp;
        }
    }

    public class BloodPressureDeletedEventArgs
    {

    }

    public class BloodPressureLoggedEventArgs
    {

    }
}
