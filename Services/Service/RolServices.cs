using Microsoft.EntityFrameworkCore;
using ScireHub.Context;
using ScireHub.Models.Entities;
using ScireHub.Services.IServices;
using ScireHub.Context;
using ScireHub.Models.Entities;
using ScireHub.Services.IServices;

namespace ScireHub.Services.Service
{
    public class RolServices : IRolServices
    {
        private readonly ApplicationDbContext _context;

        //Constructor para usar las tablas de base de datos
        public RolServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Rol>> GetRol()
        {
            try
            {

                return await _context.Roles.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

        public async Task<Rol> GetByIdRol(int id)
        {
            try
            {

                Rol response = await _context.Roles.FirstOrDefaultAsync(x => x.PkRoles == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }
        public async Task<Rol> CrearRol(Rol i)
        {
            try
            {
                Rol request = new Rol()
                {
                    PkRoles = i.PkRoles,
                    Nombre = i.Nombre,
                };

                var result = await _context.Roles.AddAsync(request);
                _context.SaveChanges();

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Rol> EditarRol(Rol i)
        {
            try
            {

                Rol rol = _context.Roles.Find(i.PkRoles);

                rol.PkRoles = i.PkRoles;
                rol.Nombre = i.Nombre;

                _context.Entry(rol).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return rol;

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }
        public bool EliminarRol(int id)
        {
            try
            {
                Rol roles = _context.Roles.Find(id);

                if (roles != null)
                {
                    var res = _context.Roles.Remove(roles);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error: " + ex.Message);
            }
        }
    }
}
