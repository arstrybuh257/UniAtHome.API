﻿using System.Threading.Tasks;

namespace UniAtHome.BLL.Interfaces.Zoom
{
    public interface IZoomAuthService
    {
        public Task<bool> AuthorizeAsync(string email, string code);

        public void RefreshAsync(string email);

        public void RevokeAsync(string email);
    }
}
