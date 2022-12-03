using System;
using System.Net;

namespace ITS.Infrastructure.Exceptions
{
    public class AppException : Exception
    {
        public object AdditionalData { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public AppException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }
        public AppException(HttpStatusCode httpStatus, string message, object additionalData) : this(httpStatus, message, null, additionalData)
        {

        }
        public AppException(HttpStatusCode httpStatus, object additionalData) : this(httpStatus, null, null, additionalData)
        {

        }
        public AppException(string message, object additionalData) : this(message, null, additionalData)
        {

        }
        public AppException(string message, Exception exception, object additionalData) :
            this(HttpStatusCode.InternalServerError, message, exception, additionalData)
        {

        }

        public AppException(HttpStatusCode statusCode, string message, Exception exception)
            : this(statusCode, message, exception, null)
        {

        }
        public AppException(HttpStatusCode statusCode, string message, Exception exception, object additionalData) : base(message, exception)
        {
            StatusCode = statusCode;
            AdditionalData = additionalData;
        }


    }
}