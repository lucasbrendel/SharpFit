using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpFit.Resources.BodyInfo.Fat;

namespace SharpFit.Events
{
    public class BodyFatGoalReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public FitbitFatGoal Goal;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goal"></param>
        public BodyFatGoalReceivedEventArgs(FitbitFatGoal goal)
        {
            this.Goal = goal;
        }
    }
}
