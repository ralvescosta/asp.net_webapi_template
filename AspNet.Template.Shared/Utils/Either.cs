namespace AspNet.Template.Shared.Utils
{
    public interface IEither<TLeft, TRight>
    {
        object Value { get; }
        bool IsRight();
        bool IsLeft();
    }

    public struct Either<TLeft, TRight> : IEither<TLeft, TRight>
    {
        public object Value { get; private set; }
        private bool _isLeft {get; set;}

        public Either(TLeft left)
        {
            Value = left;
            _isLeft = true;
        }

        public Either(TRight right)
        {
            Value = right;
            _isLeft = false;
        }
        public bool IsLeft()
        {
            return _isLeft;
        }
        public bool IsRight()
        {
            return !_isLeft;
        }
    }

    public struct Left<TLeft, TRight> : IEither<TLeft, TRight>
    {
        public object Value 
        { 
            get { return (TLeft)Value; }
            private set {}
        }

        public Left(TLeft left)
        {
            Value = left;
        }
        public bool IsLeft()
        {
            return true;
        }

        public bool IsRight()
        {
            return false;
        }
    }

    public struct Right<TLeft, TRight> : IEither<TLeft, TRight>
    {
        public object Value 
        { 
            get { return (TRight)Value; }
            private set {}
        }

        public Right(TRight right)
        {
            Value = right;
        }
        public bool IsLeft()
        {
            return false;
        }

        public bool IsRight()
        {
            return true;
        }
    }
}