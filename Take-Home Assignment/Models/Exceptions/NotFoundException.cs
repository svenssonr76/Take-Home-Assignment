using System;

namespace Take_Home_Assignment.Models.Exceptions
{
    internal class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

