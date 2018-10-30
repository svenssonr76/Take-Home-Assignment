using System;

namespace Take_Home_Assignment.Models.Exceptions
{
    internal class BadGatewayException : Exception
    {
        public BadGatewayException()
        {
        }
        public BadGatewayException(string message) : base(message)
        {
        }

        public BadGatewayException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

