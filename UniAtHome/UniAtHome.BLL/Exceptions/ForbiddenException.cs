using System.Net;

namespace UniAtHome.BLL.Exceptions
{
    public class ForbiddenException : CustomHttpException
    {
        public ForbiddenException(string message)
            : base(message, HttpStatusCode.Forbidden)
        {

        }
    }
}
