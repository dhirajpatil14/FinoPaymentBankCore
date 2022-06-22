using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Application.Behaviours
{
    [Serializable]

    public class ApiException : Exception
    {
        protected ApiException(SerializationInfo info,
      StreamingContext context) : base(info, context)
        {
        }

        public ApiException() : base() { }

        public ApiException(string message) : base(message) { }

        public ApiException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
