using Microsoft.AspNetCore.Http;

namespace Pustok.Buisness.Helpers
{
    internal static class FileHelper
    {
        public static bool CheckSize(this IFormFile file, int mb)
        {
            return file.Length <= mb * 1024 * 1024;

        }

        public static bool CheckType(this IFormFile file, string type)
        {
            return file.ContentType.Contains(type);
        }

    }
}
