using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpFit.Resources.DeviceInfo.Alarms;

namespace SharpFit.Events
{
    public class DeviceAlarmsEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public FitbitAlarms Alarms;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alarms"></param>
        public DeviceAlarmsEventArgs(FitbitAlarms alarms)
        {
            this.Alarms = alarms;
        }
    }
}
