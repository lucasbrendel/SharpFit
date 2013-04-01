using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpFit.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class MissingParameterException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public string Parameter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MissingParameterException(string parameter) : base()
        {
            this.Parameter = parameter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public MissingParameterException(string parameter, Exception ex) : base(parameter, ex)
        {
            this.Parameter = parameter;
        }
    }
}
