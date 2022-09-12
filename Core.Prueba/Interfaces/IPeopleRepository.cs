using Core.Prueba.DTOs;
using Core.Prueba.Entities;
using Core.Prueba.Entities.add;

namespace Core.Prueba.Interfaces
{
    public interface IPeopleRepository
    {
        Task<IEnumerable<Persona>> GetPeople();
        Task<Persona> GetPeopleId(int nmid);
        Task<IEnumerable<Respuestas>> InsertPeople(PeopleDto Datos);
        Task<IEnumerable<indexpeople>> indexpeople();
        Task<IEnumerable<Respuestas>> updatepeople(PeopleDto Datos);
        Task<IEnumerable<clsSearchPeople>> searchpeople(string documento);
    }
}
