using Microsoft.EntityFrameworkCore;
using ScireHub.Context;
using ScireHub.Models.Entities;
using ScireHub.Services.IServices;

namespace ScireHub.Services.Service
{
    public class UsuarioServices : IUsuarioServices
    {

        private readonly ApplicationDbContext _context;

        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Usuario> Crear(Usuario i)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Editar(Usuario i)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Usuario>> GetAll()
        {

            try
            {

                var res = await _context.Usuarios.ToListAsync();
                return res;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public Task<Usuario> GetbyId(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Usuario>> IUsuarioServices.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
