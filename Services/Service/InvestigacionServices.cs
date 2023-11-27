using Microsoft.EntityFrameworkCore;
using ScireHub.Context;
using ScireHub.Models.Entities;
using ScireHub.Services.IServices;
using System.Data;

namespace ScireHub.Services.Service
{
    public class InvestigacionServices : IInvestigacionServices
    {
        private readonly ApplicationDbContext _context;

        //Constructor para usar las tablas de base de datos
        public InvestigacionServices(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<List<Investigación>> GetInvestigaciones()
        {
            try
            {

                return await _context.Investigaciones.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

        public async Task<Investigación> GetByIdInvestigacion(int id)
        {
            try
            {

                Investigación response = await _context.Investigaciones.FirstOrDefaultAsync(x => x.PkInvestigación == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }
        public async Task<Investigación> SubirInvestigacion(Investigación i)
        {
            try
            {
                Investigación request = new Investigación()
                {
                    Nombre = i.Nombre,
                    Categoría = i.Categoría,
                    Fecha = i.Fecha,
                    FkAutor = i.FkAutor,
                };

                var result = await _context.Investigaciones.AddAsync(request);
                _context.SaveChanges();

                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }
        }

        public async Task<Investigación> EditarInvestigacion(Investigación i)
        {
            try
            {
                Investigación investigación = _context.Investigaciones.Find(i.PkInvestigación);

                investigación.Nombre = i.Nombre;
                investigación.Categoría = i.Categoría;
                investigación.Fecha = i.Fecha;
                investigación.FkAutor = i.FkAutor;

                _context.Entry(investigación).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return investigación;

            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }
        }
        public bool EliminarInvestigacion(int id)
        {
            try
            {
                Investigación investigación = _context.Investigaciones.Find(id);

                if (investigación != null)
                {
                    var res = _context.Investigaciones.Remove(investigación);
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
