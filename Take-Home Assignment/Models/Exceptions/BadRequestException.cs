using System;

namespace Take_Home_Assignment.Models.Exceptions
{
    internal class BadRequestException : Exception
    {
        public BadRequestException()
        {
        }
        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

