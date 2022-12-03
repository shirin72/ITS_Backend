using System;
using System.Net;

namespace ITS.Infrastructure.Exceptions
{
    public class InvalidObjectException : AppException
    {
        public InvalidObjectException(string message) : base(message, HttpStatusCode.BadRequest)
        {

        }

        public InvalidObjectException(object additionalData) : base(HttpStatusCode.BadRequest, additionalData)
        {

        }

        public InvalidObjectException(string message, object additionalData) : base(HttpStatusCode.BadRequest, message, additionalData)
        {

        }

        public InvalidObjectException(string message, Exception exception) :
            base(HttpStatusCode.BadRequest, message, exception)
        {

        }
        public InvalidObjectException(string message, Exception exception, object additionalData)
            : base(HttpStatusCode.BadRequest, message, exception, additionalData)
        {
        }
    }
}