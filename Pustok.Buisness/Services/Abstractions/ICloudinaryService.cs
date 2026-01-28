using Microsoft.AspNetCore.Http;

namespace Pustok.Buisness.Services.Abstractions
{
    public interface ICloudinaryService
    {
        Task<string> FileUploadAsync(IFormFile file);
        Task<bool> FileDeleteAsync(string filePath);

    }
}
