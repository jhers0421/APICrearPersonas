using AutoMapper;
using Core.Prueba.DTOs;
using Core.Prueba.Interfaces;
using Infraestructure.Prueba.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace Api.Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository _PeopleRepository;
        private readonly IMapper _mapper;

        public PeopleController(IPeopleRepository PeopleRepository, IMapper mapper)
        {
            _PeopleRepository = PeopleRepository;
            _mapper = mapper;
        }

        //[Route("GetPeople")]
        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            var Datos = await _PeopleRepository.GetPeople();
            var DatosDto = _mapper.Map<IEnumerable<PeopleDto>>(Datos);
            return Ok(DatosDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPeople(int id)
        {
            var Datos = await _PeopleRepository.GetPeopleId(id);
            var DatosDto = _mapper.Map<PeopleDto>(Datos);
            return Ok(DatosDto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPeople(PeopleDto DatosDto)
        {
            var resp = await _PeopleRepository.InsertPeople(DatosDto);
            return Ok(resp);
        }

        [HttpPut]
        public async Task<IActionResult> updatepeople(int Nmid, PeopleDto DatosDto)
        {
            DatosDto.Nmid = Nmid;
            var resp = await _PeopleRepository.updatepeople(DatosDto);
            return Ok(resp);
        }

        [Route("indexpeople")]
        [HttpGet]
        public async Task<IActionResult> indexpeople()
        {
            var Datos = await _PeopleRepository.indexpeople();
            return Ok(Datos);
        }


        [Route("searchpeople/{documento}")]
        [HttpGet]
        public async Task<IActionResult> searchpeople(string documento)
        {
            var Datos = await _PeopleRepository.searchpeople(documento);
            return Ok(Datos);
        }
    }
}
