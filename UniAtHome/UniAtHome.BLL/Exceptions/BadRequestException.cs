using System.Net;

namespace UniAtHome.BLL.Exceptions
{
    public class BadRequestException : CustomHttpException
    {
        public BadRequestException(string message)
            : base(message, HttpStatusCode.BadRequest)
        {
        }
    }
}
