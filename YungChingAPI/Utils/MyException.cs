namespace YungChingAPI.Utils
{
    public class MyException : Exception
    {
        public string ErrorCode { get; }
        public string ErrorMessage { get; }

        public MyException(string errorCode)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorCode;
        }

        public MyException(string errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
            ErrorMessage = message;
        }

        public MyException(string errorCode, string message, Exception innerException) : base(message, innerException)
        {
            ErrorCode = errorCode;
            ErrorMessage = message;
        }
    }
}
