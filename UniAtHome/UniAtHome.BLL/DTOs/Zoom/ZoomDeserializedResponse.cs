using System.Net.Http;

namespace UniAtHome.BLL.DTOs.Zoom
{
    public class ZoomDeserializedResponse<T>
    {
        public HttpResponseMessage HttpMessage { get; set; }

        public T Body { get; set; }
    }
}
