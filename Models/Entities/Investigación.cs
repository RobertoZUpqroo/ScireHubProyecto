﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScireHub.Models.Entities
{
    public class Investigación
    {
        [Key]
        public int PkInvestigación { get; set; }
        public string Nombre { get; set; }
        public string? Categoría { get; set; }
        public DateOnly Fecha { get; set; }

        [ForeignKey("Autores")]
        public int? FkAutor { get; set; }
        public Usuario Autores { get; set; }
    }
}
