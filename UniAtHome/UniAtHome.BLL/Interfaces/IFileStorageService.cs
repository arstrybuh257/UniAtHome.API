using System.Threading.Tasks;

namespace UniAtHome.BLL.Interfaces
{
    public interface IFileStorageService
    {
        Task<string> SaveImageAsync(string identifier, IFormFile image);
    }
}
