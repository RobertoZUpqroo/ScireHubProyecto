using ScireHub.Models.Entities;

namespace ScireHub.Services.IServices
{
    public interface IInvestigacionServices
    {
        public Task<List<Investigación>> GetInvestigaciones();
        public  Task<Investigación> GetByIdInvestigacion(int id);
        public Task<Investigación> SubirInvestigacion(Investigación i);
        public Task<Investigación> EditarInvestigacion(Investigación i);
        public bool EliminarInvestigacion(int id);
    }
}
