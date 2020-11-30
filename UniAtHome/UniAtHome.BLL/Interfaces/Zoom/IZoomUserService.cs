using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Zoom;

namespace UniAtHome.BLL.Interfaces.Zoom
{
    public interface IZoomUserService
    {
        Task<ZoomUserInfoDTO> GetUserInfoAsync();
    }
}
