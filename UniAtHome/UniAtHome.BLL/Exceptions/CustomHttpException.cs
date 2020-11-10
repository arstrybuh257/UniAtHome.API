using System;
using System.Net;

namespace UniAtHome.BLL.Exceptions
{
    public abstract class CustomHttpException : Exception
    {
        public int StatusCode { get; private set; }

        public CustomHttpException(string message, HttpStatusCode code) : base(message)
        {
            this.StatusCode = (int)code;
        }
    }
}
