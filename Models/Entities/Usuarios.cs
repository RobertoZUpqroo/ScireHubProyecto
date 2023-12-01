using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ScireHub.Models.Entities;

namespace ScireHub.Models.Entities
{
    public class Usuario
    {
        [Key]
        public int PKUsuario { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido1 { get; set; }

        [Required]
        public string Apellido2 { get; set; }

        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        public string Correo { get; set; }

        [Required]
        public string Contraseña { get; set; }

        [ForeignKey("Roles")]
        public int? FkRol { get; set; }
        public Rol Roles { get; set; }

        [NotMapped]
        [Display(Name = "FotoPerfil")]
        public IFormFile Img { get; set; }
        public string? UrlImagenPath { get; set; }
    }
}