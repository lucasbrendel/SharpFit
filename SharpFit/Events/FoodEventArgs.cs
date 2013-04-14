using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpFit.Resources.FoodInfo;

namespace SharpFit.Events
{
    public class FoodGetEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public FitBitFood Foods;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="foods"></param>
        public FoodGetEventArgs(FitBitFood foods)
        {
            this.Foods = foods;
        }
    }
}
