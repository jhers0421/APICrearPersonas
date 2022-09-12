using Core.Prueba.DTOs;
using Core.Prueba.Entities;
using Core.Prueba.Interfaces;
using Infraestructure.Prueba.BDatos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infraestructure.Prueba.Repositorys
{
    public class MasterdataRepository : IMasterdataRepository
    {
        private readonly PRUEBAContext _context;
        public MasterdataRepository(PRUEBAContext context)
        { _context = context; }

        public async Task<IEnumerable<DataMaestra>> GetMasterdata()
        {
            var Datos = await _context.DataMaestras.ToListAsync();
            return Datos;
        }

        public async Task<DataMaestra> GetMasterdataId(string Nmdato)
        {
            var Datos = await _context.DataMaestras.FirstOrDefaultAsync(x => x.Nmdato == Nmdato);
            return Datos;
        }

        public async Task InsertMasterdata(DataMaestra Datos)
        {
            _context.DataMaestras.Add(Datos);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EditarMasterdata(DataMaestra Datos)
        {
            var currentDatos = await GetMasterdataId(Datos.Nmdato);
            currentDatos.Nmaestro = Datos.Nmaestro;
            currentDatos.Cddato = Datos.Cddato;
            currentDatos.Dsdato = Datos.Dsdato;
            currentDatos.Cddato1 = Datos.Cddato1;
            currentDatos.Cddato2 = Datos.Cddato2;
            currentDatos.Cddato3 = Datos.Cddato3;
            currentDatos.Feregistro = Datos.Feregistro;
            currentDatos.Febaja = Datos.Febaja;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public bool ColumnExists(IDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
                if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            return false;
        }

        public async Task<IEnumerable<MasterdataDto>> selectdataMaster()
        {
            using (SqlConnection sql = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_select_dataMaster", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        await sql.OpenAsync();
                        var List = new List<MasterdataDto>();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            { List.Add(RecorrerselectdataMasters(reader)); }
                        }
                        return List;
                    }
                    catch (Exception ex)
                    {
                        string msg = ex.Message;
                        throw new Exception("Error al obtener Dato " + msg);
                    }
                    finally
                    {
                        if (sql.State == ConnectionState.Open)
                        { sql.Close(); }
                    }
                }
            }
        }
        private MasterdataDto RecorrerselectdataMasters(SqlDataReader reader)
        {
            return new MasterdataDto()
            {
                Nmdato = ColumnExists(reader, "nmdato") ? reader["nmdato"].ToString() : "",
                Dsdato = ColumnExists(reader, "dsdato") ? reader["dsdato"].ToString() : "",
            };
        }

    }
}
