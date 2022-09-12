using Core.Prueba.Entities;
using Core.Prueba.Interfaces;
using Infraestructure.Prueba.BDatos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Prueba.Repositorys
{
    public class MasterRepository : IMasterRepository
    {
        private readonly PRUEBAContext _context;
        public MasterRepository(PRUEBAContext context)
        { _context = context; }

        public async Task<IEnumerable<Maestra>> GetMaster()
        {
            var Datos = await _context.Maestras.ToListAsync();
            return Datos;
        }

        public async Task<Maestra> GetMasterId(string Nmmaestro)
        {
            var Datos = await _context.Maestras.FirstOrDefaultAsync(x => x.Nmmaestro == Nmmaestro);
            return Datos;
        }

        public async Task InsertMaster(Maestra Datos)
        {
            _context.Maestras.Add(Datos);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EditarMaster(Maestra Datos)
        {
            var currentDatos = await GetMasterId(Datos.Nmmaestro);
            currentDatos.Cdmaestro = Datos.Cdmaestro;
            currentDatos.Dsmaestro = Datos.Dsmaestro;
            currentDatos.Feregistro = Datos.Feregistro;
            currentDatos.Febaja = Datos.Febaja;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
