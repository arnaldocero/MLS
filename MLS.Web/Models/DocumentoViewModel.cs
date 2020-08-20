using Microsoft.AspNetCore.Http;
using MLS.Web.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace MLS.Web.Models
{
    public class DocumentoViewModel : DocumentoEntity
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
