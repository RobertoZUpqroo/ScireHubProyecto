using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScireHub.Models.Entities
{
    public class Investigación
    {
        [Key]
        public int PkInvestigación { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string? Categoría { get; set; }
        public string Fecha { get; set; }

        [ForeignKey("Autores")]
        public int? FkAutor { get; set; }
        public Usuario Autores { get; set; }

        [NotMapped]
        [Display(Name = "PDFArticulo")]
        public IFormFile Pdf { get; set; }
        public string UrlPdfPath { get; set; }
    }
}