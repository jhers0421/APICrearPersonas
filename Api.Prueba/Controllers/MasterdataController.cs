using AutoMapper;
using Core.Prueba.DTOs;
using Core.Prueba.Entities;
using Core.Prueba.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterdataController : ControllerBase
    {
        private readonly IMasterdataRepository _MasterdataRepository;
        private readonly IMapper _mapper;

        public MasterdataController(IMasterdataRepository MasterdataRepository, IMapper mapper)
        {
            _MasterdataRepository = MasterdataRepository;
            _mapper = mapper;
        }

        //[Route("GetMasterdata")]
        [HttpGet]
        public async Task<IActionResult> GetMasterdata()
        {
            var Datos = await _MasterdataRepository.GetMasterdata();
            var DatosDto = _mapper.Map<IEnumerable<MasterdataDto>>(Datos);
            return Ok(DatosDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMasterdata(string Nmmaestro)
        {
            var Datos = await _MasterdataRepository.GetMasterdataId(Nmmaestro);
            var DatosDto = _mapper.Map<MasterdataDto>(Datos);
            return Ok(DatosDto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertMasterdata(MasterdataDto DatosDto)
        {
            var Datos = _mapper.Map<DataMaestra>(DatosDto);
            await _MasterdataRepository.InsertMasterdata(Datos);
            return Ok(Datos);
        }

        [HttpPut]
        public async Task<IActionResult> EditarMasterdata(string Nmdato, MasterdataDto DatosDto)
        {
            var Datos = _mapper.Map<DataMaestra>(DatosDto);
            Datos.Nmdato = Nmdato;
            await _MasterdataRepository.EditarMasterdata(Datos);
            return Ok(Datos);
        }

        [Route("selectdataMaster")]
        [HttpGet]
        public async Task<IActionResult> selectdataMaster()
        {
            var Datos = await _MasterdataRepository.selectdataMaster();
            var DatosDto = _mapper.Map<IEnumerable<MasterdataDto>>(Datos);
            return Ok(DatosDto);
        }
    }
}
