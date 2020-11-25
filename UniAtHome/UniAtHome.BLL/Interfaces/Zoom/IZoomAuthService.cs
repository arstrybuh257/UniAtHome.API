using System.Threading.Tasks;

namespace UniAtHome.BLL.Interfaces.Zoom
{
    public interface IZoomAuthService
    {
        public Task<bool> AuthorizeAsync(string email, string code);

        public void Refresh(string email);

        public void Revoke(string email);
    }
}
