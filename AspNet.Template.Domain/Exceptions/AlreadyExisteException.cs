using System;

namespace AspNet.Template.Domain.Exceptions
{
    public class AlreadyExisteException : Exception
    {
        public AlreadyExisteException()
        {
        }

        public AlreadyExisteException(string message)
            : base(message)
        {
        }

        public AlreadyExisteException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}