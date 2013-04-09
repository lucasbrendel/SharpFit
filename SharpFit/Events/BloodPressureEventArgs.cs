using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpFit.Resources.BloodPressureInfo;

namespace SharpFit.Events
{
    public class BloodPressureGetEventArgs : EventArgs
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

    public class BloodPressureDeletedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isDeleted"></param>
        public BloodPressureDeletedEventArgs(bool isDeleted)
        {
            this.IsDeleted = isDeleted;
        }
    }

    public class BloodPressureLoggedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public Bp BloodPressure;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bp"></param>
        public BloodPressureLoggedEventArgs(Bp bp)
        {
            this.BloodPressure = bp;
        }
    }
}
