using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpFit.Resources.BodyInfo.Fat;

namespace SharpFit.Events
{
    public class BodyFatEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public FitBitFat Fats;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fats"></param>
        public BodyFatEventArgs(FitBitFat fats)
        {
            this.Fats = fats;
        }
    }
}
