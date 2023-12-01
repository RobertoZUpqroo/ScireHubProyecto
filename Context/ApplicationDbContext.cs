using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ScireHub.Models.Entities;

namespace ScireHub.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Investigación> Investigaciones { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Insert en la tabla usuario

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PKUsuario = 1,
                    Nombre = "Roberto",
                    Apellido1 = "Fierro",
                    Apellido2 = "Ballote",
                    NombreUsuario = "robertofb",
                    Contraseña = "1234",
                    Correo = "robertojunio2004@gmail.com",
                });
        }

    }
}