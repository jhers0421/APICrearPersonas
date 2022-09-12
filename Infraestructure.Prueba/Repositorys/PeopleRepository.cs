using Core.Prueba.DTOs;
using Core.Prueba.Entities;
using Core.Prueba.Entities.add;
using Core.Prueba.Interfaces;
using Infraestructure.Prueba.BDatos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infraestructure.Prueba.Repositorys
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly PRUEBAContext _context;
        public PeopleRepository(PRUEBAContext context)
        { _context = context; }

        public async Task<IEnumerable<Persona>> GetPeople()
        {
            var Datos = await _context.Personas.ToListAsync();
            return Datos;
        }

        public async Task<Persona> GetPeopleId(int nmid)
        {
            var Datos = await _context.Personas.FirstOrDefaultAsync(x => x.Nmid == nmid);
            return Datos;
        }

        public bool ColumnExists(IDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
                if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            return false;
        }
        public async Task<IEnumerable<Respuestas>> InsertPeople(PeopleDto Datos)
        {
            using (SqlConnection sql = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insert_people", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@documento", (Datos.Cddocumento is null) ? (object)DBNull.Value : Datos.Cddocumento));
                    cmd.Parameters.Add(new SqlParameter("@nombres", (Datos.Dsnombres is null) ? (object)DBNull.Value : Datos.Dsnombres));
                    cmd.Parameters.Add(new SqlParameter("@apellidos", (Datos.Dsapellidos is null) ? (object)DBNull.Value : Datos.Dsapellidos));
                    cmd.Parameters.Add(new SqlParameter("@fenacimiento", (Datos.Fenacimiento is null) ? (object)DBNull.Value : Datos.Fenacimiento));
                    cmd.Parameters.Add(new SqlParameter("@tipo", (Datos.Cdtipo is null) ? (object)DBNull.Value : Datos.Cdtipo));
                    cmd.Parameters.Add(new SqlParameter("@genero", (Datos.Cdgenero is null) ? (object)DBNull.Value : Datos.Cdgenero));
                    cmd.Parameters.Add(new SqlParameter("@usuario", (Datos.Cdusuario is null) ? (object)DBNull.Value : Datos.Cdusuario));
                    cmd.Parameters.Add(new SqlParameter("@direccion", (Datos.Dsdireccion is null) ? (object)DBNull.Value : Datos.Dsdireccion));
                    cmd.Parameters.Add(new SqlParameter("@telefonoFijo", (Datos.CdtelefonoFijo is null) ? (object)DBNull.Value : Datos.CdtelefonoFijo));
                    cmd.Parameters.Add(new SqlParameter("@telefonoMovil", (Datos.CdtelefonoMovil is null) ? (object)DBNull.Value : Datos.CdtelefonoMovil));
                    cmd.Parameters.Add(new SqlParameter("@email", (Datos.Dsemail is null) ? (object)DBNull.Value : Datos.Dsemail));
                    if (Datos.Dsphoto is null)
                    {
                        SqlParameter binaryFoto = cmd.Parameters.Add("@photo", SqlDbType.VarBinary, -1);
                        binaryFoto.Value = (object)Datos.Dsphoto ?? DBNull.Value;
                    }
                    else
                    { cmd.Parameters.Add(new SqlParameter("@photo", Datos.Dsphoto)); }


                    try
                    {
                        await sql.OpenAsync();
                        var List = new List<Respuestas>();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            { List.Add(RecorrerRespuesta(reader)); }
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
        private Respuestas RecorrerRespuesta(SqlDataReader reader)
        {
            return new Respuestas()
            {
                respuesta = ColumnExists(reader, "Respuesta") ? reader["Respuesta"].ToString() : "",
                nmid = Convert.ToInt32(reader["Nmid"] != DBNull.Value ? reader["Nmid"] : 0)
            };
        }

        public async Task<IEnumerable<indexpeople>> indexpeople()
        {
            using (SqlConnection sql = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_select_index_people", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        await sql.OpenAsync();
                        var List = new List<indexpeople>();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            { List.Add(Recorrerindexpeople(reader)); }
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
        private indexpeople Recorrerindexpeople(SqlDataReader reader)
        {
            return new indexpeople()
            {
                Nmid = Convert.ToInt32(reader["nmid"] != DBNull.Value ? reader["nmid"] : 0),
                Cddocumento = ColumnExists(reader, "cddocumento") ? reader["cddocumento"].ToString() : "",
                DsnombresYapellidos = ColumnExists(reader, "Persona") ? reader["Persona"].ToString() : "",
                TipoPersona = ColumnExists(reader, "tipoPersona") ? reader["tipoPersona"].ToString() : "",
                Cdgenero = ColumnExists(reader, "cdgenero") ? reader["cdgenero"].ToString() : "",
                Feregistro = Convert.ToDateTime(reader["feregistro"] != DBNull.Value ? reader["feregistro"] : null),
            };
        }
        public async Task<IEnumerable<Respuestas>> updatepeople(PeopleDto Datos)
        {
            using (SqlConnection sql = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_people", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nmind", (Datos.Nmid is null) ? (object)DBNull.Value : Datos.Nmid));
                    cmd.Parameters.Add(new SqlParameter("@documento", (Datos.Cddocumento is null) ? (object)DBNull.Value : Datos.Cddocumento));
                    cmd.Parameters.Add(new SqlParameter("@nombres", (Datos.Dsnombres is null) ? (object)DBNull.Value : Datos.Dsnombres));
                    cmd.Parameters.Add(new SqlParameter("@apellidos", (Datos.Dsapellidos is null) ? (object)DBNull.Value : Datos.Dsapellidos));
                    cmd.Parameters.Add(new SqlParameter("@fenacimiento", (Datos.Fenacimiento is null) ? (object)DBNull.Value : Datos.Fenacimiento));
                    cmd.Parameters.Add(new SqlParameter("@tipo", (Datos.Cdtipo is null) ? (object)DBNull.Value : Datos.Cdtipo));
                    cmd.Parameters.Add(new SqlParameter("@genero", (Datos.Cdgenero is null) ? (object)DBNull.Value : Datos.Cdgenero));
                    cmd.Parameters.Add(new SqlParameter("@usuario", (Datos.Cdusuario is null) ? (object)DBNull.Value : Datos.Cdusuario));
                    cmd.Parameters.Add(new SqlParameter("@direccion", (Datos.Dsdireccion is null) ? (object)DBNull.Value : Datos.Dsdireccion));
                    cmd.Parameters.Add(new SqlParameter("@telefonoFijo", (Datos.CdtelefonoFijo is null) ? (object)DBNull.Value : Datos.CdtelefonoFijo));
                    cmd.Parameters.Add(new SqlParameter("@telefonoMovil", (Datos.CdtelefonoMovil is null) ? (object)DBNull.Value : Datos.CdtelefonoMovil));
                    cmd.Parameters.Add(new SqlParameter("@email", (Datos.Dsemail is null) ? (object)DBNull.Value : Datos.Dsemail));
                    cmd.Parameters.Add(new SqlParameter("@darBaja", (Datos.darBaja is null) ? (object)DBNull.Value : Datos.darBaja));
                    if (Datos.Dsphoto is null)
                    {
                        SqlParameter binaryFoto = cmd.Parameters.Add("@photo", SqlDbType.VarBinary, -1);
                        binaryFoto.Value = (object)Datos.Dsphoto ?? DBNull.Value;
                    }
                    else
                    { cmd.Parameters.Add(new SqlParameter("@photo", Datos.Dsphoto)); }


                    try
                    {
                        await sql.OpenAsync();
                        var List = new List<Respuestas>();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            { List.Add(Recorrerupdatepeople(reader)); }
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
        private Respuestas Recorrerupdatepeople(SqlDataReader reader)
        {
            return new Respuestas()
            {
                respuesta = ColumnExists(reader, "Respuesta") ? reader["Respuesta"].ToString() : "",
                nmid = Convert.ToInt32(reader["Nmid"] != DBNull.Value ? reader["Nmid"] : 0)
            };
        }

        public async Task<IEnumerable<clsSearchPeople>> searchpeople(string documento)
        {
            using (SqlConnection sql = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_search_people", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@documento", (documento is null) ? (object)DBNull.Value : documento));

                    try
                    {
                        await sql.OpenAsync();
                        clsSearchPeople obj = new clsSearchPeople();
                        var List = new List<clsSearchPeople>();
                        var ListPeopleDto = new List<PeopleDto>();
                        var ListPatientsDto = new List<PatientsDto>();
                        var ListMasterdataDto = new List<MasterdataDto>();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            { ListPeopleDto.Add(RecorrerListPeopleDto(reader)); }

                            if (await reader.NextResultAsync())
                            {
                                while (await reader.ReadAsync())
                                { ListPatientsDto.Add(RecorrerPatientsDto(reader)); }
                            }
                            if (await reader.NextResultAsync())
                            {
                                while (await reader.ReadAsync())
                                { ListMasterdataDto.Add(RecorrerselectdataMasters(reader)); }
                            }
                            obj.PeopleDto = ListPeopleDto;
                            obj.PatientsDto = ListPatientsDto;
                            obj.MasterdataDto = ListMasterdataDto;

                            List.Add(obj);
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
        private PeopleDto RecorrerListPeopleDto(SqlDataReader reader)
        {
            return new PeopleDto()
            {
                Nmid = Convert.ToInt32(reader["nmid"] != DBNull.Value ? reader["nmid"] : 0),
                Cddocumento = ColumnExists(reader, "cddocumento") ? reader["cddocumento"].ToString() : "",
                Dsnombres = ColumnExists(reader, "dsnombres") ? reader["dsnombres"].ToString() : "",
                Dsapellidos = ColumnExists(reader, "dsapellidos") ? reader["dsapellidos"].ToString() : "",
                Fenacimiento = Convert.ToDateTime(reader["fenacimiento"] != DBNull.Value ? reader["fenacimiento"] : null),
                Cdtipo = ColumnExists(reader, "cdtipo") ? reader["cdtipo"].ToString() : "",
                Cdgenero = ColumnExists(reader, "cdgenero") ? reader["cdgenero"].ToString() : "",
                Cdusuario = ColumnExists(reader, "cdusuario") ? reader["cdusuario"].ToString() : "",
                Dsdireccion = ColumnExists(reader, "dsdireccion") ? reader["dsdireccion"].ToString() : "",
                Dsphoto= ColumnExists(reader, "dsphoto") && reader["dsphoto"] != DBNull.Value ? ((byte[])reader["dsphoto"]) : null,
                CdtelefonoFijo = ColumnExists(reader, "cdtelefono_fijo") ? reader["cdtelefono_fijo"].ToString() : "",
                CdtelefonoMovil = ColumnExists(reader, "cdtelefono_movil") ? reader["cdtelefono_movil"].ToString() : "",
                Dsemail = ColumnExists(reader, "dsemail") ? reader["dsemail"].ToString() : "",
                darBaja = Convert.ToBoolean(reader["darBaja"] != DBNull.Value ? reader["darBaja"] : 0)
            };
        }
        private PatientsDto RecorrerPatientsDto(SqlDataReader reader)
        {
            return new PatientsDto()
            {
                Dseps = ColumnExists(reader, "dseps") ? reader["dseps"].ToString() : "",
                Dsarl = ColumnExists(reader, "dsarl") ? reader["dsarl"].ToString() : "",
                Cdusuario = ColumnExists(reader, "cdusuario") ? reader["cdusuario"].ToString() : "",
                Dscondicion = ColumnExists(reader, "dscondicion") ? reader["dscondicion"].ToString() : "",
            };
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
