using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BankCloud.Services.Interfaces
{
    public interface ICloudinaryService
    {
        Task<string> UploadPictureAsync(IFormFile pictureFile, string fileName);
    }
}
