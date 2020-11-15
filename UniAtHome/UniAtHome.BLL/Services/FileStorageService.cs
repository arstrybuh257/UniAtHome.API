using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace UniAtHome.BLL.Services
{
    public class FileStorageService 
    {
        private readonly Cloudinary cloudinary;

        public FileStorageService(StorageServiceConfig config)
        {
            var account = new Account(config.CloudName, config.ApiKey, config.ApiSecret);
            cloudinary = new Cloudinary(account);
        }

        /// <returns>Path to file or null if there is some error</returns>
        public async Task<string> SaveImageAsync(string identifier, IFormFile image)
        {
            if (image != null)
            {
                var uploadResult = await cloudinary.UploadAsync(new ImageUploadParams()
                {
                    File = new FileDescription(image.FileName, image.OpenReadStream()),
                    PublicId = identifier
                });

                return uploadResult.StatusCode != System.Net.HttpStatusCode.OK ? null : uploadResult.Url.AbsoluteUri;
            }

            return null;
        }
    }
}
