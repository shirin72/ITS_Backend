using System.Collections.Generic;
using FluentValidation.Results;
using ITS.Infrastructure.Exceptions;

namespace ITS.Infrastructure.Extensions
{
    public static class RaiseExceptionIfInvalidObject
    {
        public static void RaiseExceptionIfInvalid(this ValidationResult src)
        {

            if (!src.IsValid)
            {
                var errors = new List<object>();

                foreach (var error in src.Errors)
                {
                    errors.Add(new { error.PropertyName, error.ErrorMessage });
                }

                throw new InvalidObjectException(errors);
            }

        }
    }
}