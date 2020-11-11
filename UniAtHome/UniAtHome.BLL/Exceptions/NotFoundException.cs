using System.Net;

namespace UniAtHome.BLL.Exceptions
{
    public class NotFoundException : CustomHttpException
    {
        public NotFoundException(string message)
            : base(message, HttpStatusCode.NotFound)
        {

        }
    }
}
