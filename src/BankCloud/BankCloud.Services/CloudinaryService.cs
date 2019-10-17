using BankCloud.Services.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace BankCloud.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private const string PRODUCT_PICTURE_FOLDER_NAME = "product_images";
        private const int PRODUCT_PICTURE_HEIGHT = 693;
        private const int PRODUCT_PICTURE_WIDTH = 700;

        private readonly Cloudinary cloudinaryUtility;

        public CloudinaryService(Cloudinary cloudinaryUtility)
        {
            this.cloudinaryUtility = cloudinaryUtility;
        }

        public async Task<string> UploadPictureAsync(IFormFile pictureFile, string fileName)
        {
            byte[] destinationData;

            using (var ms = new MemoryStream())
            {
                await pictureFile.CopyToAsync(ms);
                destinationData = ms.ToArray();
            }

            UploadResult uploadResult = null;

            using (var ms = new MemoryStream(destinationData))
            {
                ImageUploadParams uploadParams = new ImageUploadParams
                {
                    Folder = PRODUCT_PICTURE_FOLDER_NAME,
                    File = new FileDescription(fileName, ms),
                    Transformation = new Transformation()
                                        .Height(PRODUCT_PICTURE_HEIGHT)
                                        .Width(PRODUCT_PICTURE_WIDTH)
                };

                uploadResult = this.cloudinaryUtility.Upload(uploadParams);
            }

            return uploadResult?.SecureUri.AbsoluteUri;
        }
    }
}
