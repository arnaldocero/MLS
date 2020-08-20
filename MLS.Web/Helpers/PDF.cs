using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MLS.Web.Helpers
{
    public class PDF : IPDF
    {
        public async Task<string> UploadImageAsync(IFormFile pdfFile, string folder)
        {
            string guid = Guid.NewGuid().ToString();
            string file = $"{guid}.pdf";
            string path = Path.Combine(
                Directory.GetCurrentDirectory(),
                $"wwwroot\\pdf\\{folder}",
                file);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await pdfFile.CopyToAsync(stream);
            }

            return $"~/pdf/{folder}/{file}";
        }

    }
}
