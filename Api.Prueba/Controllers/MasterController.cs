using AutoMapper;
using Core.Prueba.DTOs;
using Core.Prueba.Entities;
using Core.Prueba.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterRepository _MasterRepository;
        private readonly IMapper _mapper;

        public MasterController(IMasterRepository MasterRepository, IMapper mapper)
        {
            _MasterRepository = MasterRepository;
            _mapper = mapper;
        }

        //[Route("GetMaster")]
        [HttpGet]
        public async Task<IActionResult> GetMaster()
        {
            var Datos = await _MasterRepository.GetMaster();
            var DatosDto = _mapper.Map<IEnumerable<MasterDto>>(Datos);
            return Ok(DatosDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaster(string Nmmaestro)
        {
            var Datos = await _MasterRepository.GetMasterId(Nmmaestro);
            var DatosDto = _mapper.Map<MasterDto>(Datos);
            return Ok(DatosDto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertMaster(MasterDto DatosDto)
        {
            var Datos = _mapper.Map<Maestra>(DatosDto);
            await _MasterRepository.InsertMaster(Datos);
            return Ok(Datos);
        }

        [HttpPut]
        public async Task<IActionResult> EditarMaster(string Nmmaestro, MasterDto DatosDto)
        {
            var Datos = _mapper.Map<Maestra>(DatosDto);
            Datos.Nmmaestro = Nmmaestro;
            await _MasterRepository.EditarMaster(Datos);
            return Ok(Datos);
        }
    }
}
