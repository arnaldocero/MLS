using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MLS.Web.Data.Entities
{
    public class DocumentoEntity
    {
        public int Id { get; set; }

		[Display(Name = "Nombre del Documento")]
		[MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
		[Required]
		public string Name { get; set; }

        [Display(Name = "Documento del Dueño")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; }

        [Display(Name = "Nombres y Apellidos del Dueño")]
        [MaxLength(250, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; }

        [Display(Name = "Archivo PDF")]
		public string pdfUrl { get; set; }

		[Display(Name = "Fecha de subida")]
		public DateTime UploadDate { get; set; }
        public UserEntity User { get; set; }


    }
}
