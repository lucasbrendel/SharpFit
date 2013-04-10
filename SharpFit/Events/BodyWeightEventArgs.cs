using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpFit.Resources.BodyInfo.Weight;

namespace SharpFit.Events
{
    public class BodyWeightGetEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public FitBitWeight Weight;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="weight"></param>
        public BodyWeightGetEventArgs(FitBitWeight weight)
        {
            this.Weight = weight;
        }
    }
}
