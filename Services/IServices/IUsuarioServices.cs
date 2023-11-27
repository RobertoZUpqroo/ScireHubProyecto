using ScireHub.Models.Entities;

namespace ScireHub.Services.IServices
{
    public interface IUsuarioServices
    {

        public Task<List<Usuario>> GetUsuarios();
        public Task<Usuario> GetByIdUsuario(int id);

        public Task<Usuario> CrearUsuario(Usuario i);
        public Task<Usuario> EditarUsuario(Usuario i);
        public bool EliminarUsuario(int id);
    }
}
