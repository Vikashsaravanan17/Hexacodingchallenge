using System;

namespace CareerHub.exception
{
    public class CareerHubException : Exception
    {
        public CareerHubException() { }

        public CareerHubException(string message)
            : base(message) { }

        public CareerHubException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}

