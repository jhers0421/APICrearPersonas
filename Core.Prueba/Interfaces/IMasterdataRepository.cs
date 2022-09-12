using Core.Prueba.DTOs;
using Core.Prueba.Entities;

namespace Core.Prueba.Interfaces
{
    public interface IMasterdataRepository
    {
        Task<IEnumerable<DataMaestra>> GetMasterdata();
        Task<DataMaestra> GetMasterdataId(string Nmmaestro);
        Task InsertMasterdata(DataMaestra Datos);
        Task<bool> EditarMasterdata(DataMaestra Datos);
        Task<IEnumerable<MasterdataDto>> selectdataMaster();
    }
}
