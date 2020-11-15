using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using UniAtHome.BLL.Interfaces;
using UniAtHome.BLL.Options;

namespace UniAtHome.BLL.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly Cloudinary cloudinary;

        public FileStorageService(IOptions<StorageServiceConfig> options)
        {
            var config = options.Value;
            var account = new Account(config.CloudName, config.ApiKey, config.ApiSecret);
            this.cloudinary = new Cloudinary(account);
        }

        /// <returns>Path to file or null if there is some error</returns>
        public async Task<string> SaveImageAsync(string identifier, IFormFile image)
        {
            if (image != null)
            {
                var uploadResult = await this.cloudinary.UploadAsync(new ImageUploadParams()
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
