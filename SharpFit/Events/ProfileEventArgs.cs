using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpFit.Resources.User;

namespace SharpFit.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class ProfileEventArgs : EventArgs
    {
        private FitBitUser _profile;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pro"></param>
        public ProfileEventArgs(FitBitUser pro)
        {
            _profile = pro;
        }

        /// <summary>
        /// 
        /// </summary>
        public FitBitUser UserProfile
        {
            get { return _profile; }
        }
    }
}
