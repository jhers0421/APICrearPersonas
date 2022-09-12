using AutoMapper;
using Core.Prueba.DTOs;
using Core.Prueba.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsRepositorys _PatientsRepository;
        private readonly IMapper _mapper;

        public PatientsController(IPatientsRepositorys PatientsRepository, IMapper mapper)
        {
            _PatientsRepository = PatientsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var Datos = await _PatientsRepository.GetPatients();
            var DatosDto = _mapper.Map<IEnumerable<PatientsDto>>(Datos);
            return Ok(DatosDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatients(int id)
        {
            var Datos = await _PatientsRepository.GetPatientsId(id);
            var DatosDto = _mapper.Map<PatientsDto>(Datos);
            return Ok(DatosDto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPatients(PatientsDto DatosDto)
        {
            var resp = await _PatientsRepository.InsertPatients(DatosDto);
            return Ok(resp);
        }

        [HttpPut]
        public async Task<IActionResult> EditarPatients(int nmind_persona, PatientsDto DatosDto)
        {
            DatosDto.NmindPersona = nmind_persona;
            var resp = await _PatientsRepository.updatepatients(DatosDto);
            return Ok(resp);
        }

        [Route("searchpatients/{documento}")]
        [HttpGet]
        public async Task<IActionResult> searchpatients(string documento)
        {
            var Datos = await _PatientsRepository.searchpatients(documento);
            return Ok(Datos);
        }

        [Route("indexpatients")]
        [HttpGet]
        public async Task<IActionResult> indexpatients()
        {
            var Datos = await _PatientsRepository.indexpatients();
            return Ok(Datos);
        }

        [Route("patientfullinfo/{nmind}")]
        [HttpGet]
        public async Task<IActionResult> patientfullinfo(int? nmind)
        {
            var Datos = await _PatientsRepository.patientfullinfo(nmind);
            return Ok(Datos);
        }
    }
}
