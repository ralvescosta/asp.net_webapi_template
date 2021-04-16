using System;

namespace AspNet.Template.Domain
{
    public class InternalErrorException : Exception
    {
        public InternalErrorException()
        {
        }

        public InternalErrorException(string message)
            : base(message)
        {
        }

        public InternalErrorException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}