using Microsoft.AspNetCore.Identity;
using MLS.Common.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MLS.Web.Data.Entities
{
    public class UserEntity : IdentityUser
    {
        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; }

        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string Address { get; set; }
        [Display(Name = "Celular")]
        [MaxLength(10, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        public string Celular { get; set; }

        [Display(Name = "Imagen")]
        public string PicturePath { get; set; }

        [Display(Name = "Tipo de usuario")]
        public UserType UserType { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";
        public ICollection<DocumentoEntity> Documento { get; set; }

    }
}
