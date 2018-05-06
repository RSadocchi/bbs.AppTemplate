using System;
using System.Collections.Generic;
using System.Text;

namespace bbs.AppTemplate.Models
{
    public class APIException : Exception
    {
        #region DEFAULT CONSTRUCTORS
        public APIException() : base() { }
        public APIException(string message) : base(message) { }
        public APIException(string message, Exception innerException) : base(message, innerException) { }
        #endregion

        #region CUSTOM CONSTRUCTORS

        #endregion
    }
}
