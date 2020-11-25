using System;
using System.Collections.Generic;
using System.Text;

namespace UniAtHome.BLL.Interfaces.Zoom
{
    public interface IZoomAuthService
    {
        public bool Authorize(string email, string code);

        public void Refresh(string email);

        public void Revoke(string email);
    }
}
