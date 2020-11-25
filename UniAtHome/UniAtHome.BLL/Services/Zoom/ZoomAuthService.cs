using System;
using UniAtHome.BLL.Interfaces.Zoom;

namespace UniAtHome.BLL.Services.Zoom
{
    public class ZoomAuthService : IZoomAuthService
    {
        public bool Authorize(string email, string code)
        {
            const string apiUrl = @"oauth/token";

            throw new NotImplementedException();
        }

        public void Refresh(string email)
        {
            throw new NotImplementedException();
        }

        public void Revoke(string email)
        {
            throw new NotImplementedException();
        }
    }
}
