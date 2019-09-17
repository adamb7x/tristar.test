using System;

namespace TRISTAR.Assessment.Infrastructure
{
    public class EmptyGuidException : ArgumentException
    {
        private const string ExceptionMessage = "A non-empty GUID is required!";

        public EmptyGuidException()
            : base(ExceptionMessage)
        {
        }

        public EmptyGuidException(string paramName)
            : base(ExceptionMessage, paramName)
        {
        }

        public EmptyGuidException(string paramName, Exception innerException)
            : base(ExceptionMessage, paramName, innerException)
        {
        }
    }
}
