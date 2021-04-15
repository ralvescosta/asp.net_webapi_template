using System;

namespace AspNet.Manage.StatusCode.Domain
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