using System;

namespace NasaApi.Services.ServiceResult
{
    public class Violation
    {
        public string Message { get; }
        public Exception Exception { get; }

        public Violation(string message)
        {
            Message = message;
        }

        public Violation(Exception exception)
        {
            Exception = exception;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Message))
            {
                return Message;
            }

            if (Exception != null)
            {
                return Exception.Message;
            }

            return base.ToString();
        }
    }
}
