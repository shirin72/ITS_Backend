using System;
using System.Net;

namespace ITS.Infrastructure.Exceptions
{
    public class ServiceException : AppException
    {
        public ServiceException(string message) : base(HttpStatusCode.Conflict, message)
        {

        }
        public ServiceException(object additionalData) : base(HttpStatusCode.Conflict, additionalData)
        {

        }
        public ServiceException(string message, object additionalData) : base(HttpStatusCode.Conflict, message, additionalData)
        {

        }
        public ServiceException(string message, Exception exception) : base(HttpStatusCode.Conflict, message, exception)
        {

        }
        public ServiceException(string message, Exception exception, object additionalData) : base(HttpStatusCode.Conflict, message, exception, additionalData)
        {

        }

    }
}