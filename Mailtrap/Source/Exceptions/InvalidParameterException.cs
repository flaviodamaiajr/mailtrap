using Mailtrap.Source.Resources;
using System;

namespace Mailtrap.Source.Exceptions
{
    public class InvalidParameterException : Exception
    {
        public InvalidParameterException(string? message) : base(message)
        {
        }
        public static void ThrowIfNull(object? argument, string? paramName = null)
        {
            if (argument is null)
            {
                throw new InvalidParameterException(string.Format(ExceptionsMessages.Parameter_Cannot_Be_Null, paramName));
            }
        }
    }
}