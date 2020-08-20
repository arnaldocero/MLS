using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MLS.Web.Helpers
{
    public interface IPDF
    {
        Task<string> UploadImageAsync(IFormFile pdfFile, string folder);
    }
}
