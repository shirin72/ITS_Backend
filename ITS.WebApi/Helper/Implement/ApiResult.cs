using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ITS.WebApi.Helper.Implement
{
    public class ApiResult
    {
        public ApiResult(HttpStatusCode statusCode, string message = null, Error error = null)
        {
            StatusCode = statusCode;
            Message = message;
            Error = error;
        }

        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public Error Error { get; set; }

        #region Implicit Operators
        public static implicit operator ApiResult(OkResult result)
        {
            return new ApiResult(HttpStatusCode.OK);
        }

        public static implicit operator ApiResult(BadRequestResult result)
        {
            return new ApiResult(HttpStatusCode.BadRequest);
        }

        public static implicit operator ApiResult(BadRequestObjectResult result)
        {
            var message = result.Value.ToString();
            if (result.Value is SerializableError errors)
            {
                var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
                message = string.Join(" | ", errorMessages);
            }
            var error = new Error(message);
            return new ApiResult(HttpStatusCode.BadRequest, null, error);
        }

        public static implicit operator ApiResult(ContentResult result)
        {
            return new ApiResult(HttpStatusCode.OK, result.Content);
        }

        public static implicit operator ApiResult(NotFoundResult result)
        {
            return new ApiResult(HttpStatusCode.NotFound);
        }

        public static implicit operator ApiResult(UnauthorizedResult result)
        {
            return new ApiResult(HttpStatusCode.Unauthorized);
        }

        #endregion
    }

    public class ApiResult<T> : ApiResult where T : class
    {
        public ApiResult(T data, HttpStatusCode statusCode, string message = null, Error error = null) : base(statusCode, message, error)
        {
            Data = data;
            Error = error;
            Message = message;
        }
        public T Data { get; protected set; }


        #region Implicit Operator

        public static implicit operator ApiResult<T>(T result)
        {
            return new ApiResult<T>(result, HttpStatusCode.OK);
        }

        public static implicit operator ApiResult<T>(OkResult result)
        {
            return new ApiResult<T>(null, HttpStatusCode.OK);
        }

        public static implicit operator ApiResult<T>(OkObjectResult result)
        {
            return new ApiResult<T>((T)result.Value, HttpStatusCode.OK);
        }

        public static implicit operator ApiResult<T>(BadRequestObjectResult result)
        {
            var message = result.Value.ToString();
            if (result.Value is SerializableError errors)
            {
                var errorMessages = errors.SelectMany(p => (string[])p.Value).Distinct();
                message = string.Join(" | ", errorMessages);
            }
            var error = new Error(message);
            return new ApiResult<T>(null, HttpStatusCode.BadRequest, null, error);
        }

        public static implicit operator ApiResult<T>(ContentResult result)
        {
            return new ApiResult<T>(null, HttpStatusCode.OK, result.Content);
        }

        public static implicit operator ApiResult<T>(NotFoundResult result)
        {
            return new ApiResult<T>(null, HttpStatusCode.NotFound);
        }

        public static implicit operator ApiResult<T>(NotFoundObjectResult result)
        {
            return new ApiResult<T>((T)result.Value, HttpStatusCode.NotFound);
        }
        public static implicit operator ApiResult<T>(UnauthorizedResult result)
        {
            return new ApiResult<T>(null, HttpStatusCode.Unauthorized);
        }

        #endregion

    }
}