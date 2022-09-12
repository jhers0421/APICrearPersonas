using Core.Prueba.Entities;

namespace Core.Prueba.Interfaces
{
    public interface IMasterRepository
    {
        Task<IEnumerable<Maestra>> GetMaster();
        Task<Maestra> GetMasterId(string Nmmaestro);
        Task InsertMaster(Maestra Datos);
        Task<bool> EditarMaster(Maestra Datos);
    }
}
