using AutoMapper;
using Core.Prueba.DTOs;
using Core.Prueba.Entities;

namespace Infraestructure.Prueba.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<DataMaestra, MasterdataDto>();
            CreateMap<MasterdataDto, DataMaestra>();

            CreateMap<Maestra, MasterDto>();
            CreateMap<MasterDto, Maestra>();

            CreateMap<Paciente, PatientsDto>();
            CreateMap<PatientsDto, Paciente>();

            CreateMap<Persona, PeopleDto>();
            CreateMap<PeopleDto, Persona>();
        }
    }
}
