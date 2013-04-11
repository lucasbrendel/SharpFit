using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpFit.Resources.BodyInfo.Weight;
namespace SharpFit.Events
{
    public class BodyWeightGoalEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public FitbitWeightGoal Goal;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goal"></param>
        public BodyWeightGoalEventArgs(FitbitWeightGoal goal)
        {
            this.Goal = goal;
        }
    }
}
