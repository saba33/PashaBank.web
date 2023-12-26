using Microsoft.AspNetCore.Http;

namespace PashaBank.Services.Infrastructure.Helper
{
    public static class ProcessImage
    {
        public static async Task<byte[]> ProcessImageAsync(IFormFile image)
        {
            using (var memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);
                byte[] imageData = memoryStream.ToArray();

                return imageData;
            }
        }
    }
}
