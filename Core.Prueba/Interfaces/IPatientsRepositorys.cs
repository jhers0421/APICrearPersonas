using Core.Prueba.DTOs;
using Core.Prueba.Entities;
using Core.Prueba.Entities.add;

namespace Core.Prueba.Interfaces
{
    public interface IPatientsRepositorys
    {
        Task<IEnumerable<Paciente>> GetPatients();
        Task<Paciente> GetPatientsId(int nmid);
        Task<IEnumerable<Respuestas>> InsertPatients(PatientsDto Datos);
        Task<IEnumerable<PatientsDto>> searchpatients(string? documento);
        Task<IEnumerable<indexpatients>> indexpatients();
        Task<IEnumerable<patientsfullinfo>> patientfullinfo(int? nmind);
        Task<IEnumerable<Respuestas>> updatepatients(PatientsDto Datos);
    }
}
