using System;

namespace AspNet.Template.Shared.Utils
{
    public struct Result<T>
    {
        public T Value { get; private set; }
        private Exception Excpetion {get; set;}
        public bool IsFaulted {get; set;}

        public Result(T left)
        {
            Value = left;
            Excpetion = (Exception)null;
            IsFaulted = false;
        }

        public Result(Exception exception)
        {
            Value = default(T);
            Excpetion = exception;
            IsFaulted = true;
        }

        public R Match<R>(Func<T, R> Success, Func<Exception, R> Fail) =>
            IsFaulted
                ? Fail(Excpetion)
                : Success(Value);
    }
}