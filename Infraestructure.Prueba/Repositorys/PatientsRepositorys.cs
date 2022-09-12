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
    public class PatientsRepositorys : IPatientsRepositorys
    {
        private readonly PRUEBAContext _context;
        public PatientsRepositorys(PRUEBAContext context)
        { _context = context; }

        public async Task<IEnumerable<Paciente>> GetPatients()
        {
            var Datos = await _context.Pacientes.ToListAsync();
            return Datos;
        }

        public async Task<Paciente> GetPatientsId(int nmid)
        {
            var Datos = await _context.Pacientes.FirstOrDefaultAsync(x => x.Nmind == nmid);
            return Datos;
        }

        public bool ColumnExists(IDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
                if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            return false;
        }
        public async Task<IEnumerable<Respuestas>> InsertPatients(PatientsDto Datos)
        {
            using (SqlConnection sql = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_insert_patients", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nmind_persona", (Datos.NmindPersona is null) ? (object)DBNull.Value : Datos.NmindPersona));
                    cmd.Parameters.Add(new SqlParameter("@eps", (Datos.Dseps is null) ? (object)DBNull.Value : Datos.Dseps));
                    cmd.Parameters.Add(new SqlParameter("@arl", (Datos.Dsarl is null) ? (object)DBNull.Value : Datos.Dsarl));
                    cmd.Parameters.Add(new SqlParameter("@usuario", (Datos.Cdusuario is null) ? (object)DBNull.Value : Datos.Cdusuario));
                    cmd.Parameters.Add(new SqlParameter("@condicion", (Datos.Dscondicion is null) ? (object)DBNull.Value : Datos.Dscondicion));

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
                respuesta = ColumnExists(reader, "Respuesta") ? reader["Respuesta"].ToString() : ""
            };
        }
        public async Task<IEnumerable<PatientsDto>> searchpatients(string? documento)
        {
            using (SqlConnection sql = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_search_patients", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@documento", (documento is null) ? (object)DBNull.Value : documento));

                    try
                    {
                        await sql.OpenAsync();
                        var List = new List<PatientsDto>();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            { List.Add(Recorrersearchpatients(reader)); }
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
        private PatientsDto Recorrersearchpatients(SqlDataReader reader)
        {
            return new PatientsDto()
            {
                Dseps = ColumnExists(reader, "dseps") ? reader["dseps"].ToString() : "",
                Dsarl = ColumnExists(reader, "dsarl") ? reader["dsarl"].ToString() : "",
                Feregistro = Convert.ToDateTime(reader["feregistro"] != DBNull.Value ? reader["feregistro"] : null),
                Febaja = Convert.ToDateTime(reader["febaja"] != DBNull.Value ? reader["febaja"] : null),
                Cdusuario = ColumnExists(reader, "cdusuario") ? reader["cdusuario"].ToString() : "",
                Dscondicion = ColumnExists(reader, "dscondicion") ? reader["dscondicion"].ToString() : "",
            };
        }

        public async Task<IEnumerable<indexpatients>> indexpatients()
        {
            using (SqlConnection sql = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_select_index_patients", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        await sql.OpenAsync();
                        var List = new List<indexpatients>();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            { List.Add(Recorrerindexpatients(reader)); }
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
        private indexpatients Recorrerindexpatients(SqlDataReader reader)
        {
            return new indexpatients()
            {
                Nmind = Convert.ToInt32(reader["nmind"] != DBNull.Value ? reader["nmind"] : 0),
                Cddocumento = ColumnExists(reader, "cddocumento") ? reader["cddocumento"].ToString() : "",
                DsnombresYapellidos = ColumnExists(reader, "Paciente") ? reader["Paciente"].ToString() : "",
                Dseps = ColumnExists(reader, "dseps") ? reader["dseps"].ToString() : "",
                Dsarl = ColumnExists(reader, "dsarl") ? reader["dsarl"].ToString() : "",
            };
        }

        public async Task<IEnumerable<patientsfullinfo>> patientfullinfo(int? nmind)
        {
            using (SqlConnection sql = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_select_patients_full_info", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nmind", (nmind is null) ? (object)DBNull.Value : nmind));

                    try
                    {
                        await sql.OpenAsync();
                        var List = new List<patientsfullinfo>();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            { List.Add(Recorrerpatientfullinfo(reader)); }
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
        private patientsfullinfo Recorrerpatientfullinfo(SqlDataReader reader)
        {
            return new patientsfullinfo()
            {
                Cddocumento = ColumnExists(reader, "cddocumento") ? reader["cddocumento"].ToString() : "",
                DsnombresYapellidos = ColumnExists(reader, "Paciente") ? reader["Paciente"].ToString() : "",
                Fenacimiento = Convert.ToDateTime(reader["fenacimiento"] != DBNull.Value ? reader["fenacimiento"] : null),
                Cdgenero = ColumnExists(reader, "cdgenero") ? reader["cdgenero"].ToString() : "",
                FeregistroPersona = Convert.ToDateTime(reader["FeregistroPersona"] != DBNull.Value ? reader["FeregistroPersona"] : null),
                FebajaPersona = Convert.ToDateTime(reader["FebajaPersona"] != DBNull.Value ? reader["FebajaPersona"] : null),
                CdusuarioPersona = ColumnExists(reader, "CdusuarioPersona") ? reader["CdusuarioPersona"].ToString() : "",
                Dsdireccion = ColumnExists(reader, "dsdireccion") ? reader["dsdireccion"].ToString() : "",
                Dsphoto = ColumnExists(reader, "dsphoto") && reader["dsphoto"] != DBNull.Value ? ((byte[])reader["dsphoto"]) : null,
                CdtelefonoFijo = ColumnExists(reader, "cdtelefono_fijo") ? reader["cdtelefono_fijo"].ToString() : "",
                CdtelefonoMovil = ColumnExists(reader, "cdtelefono_movil") ? reader["cdtelefono_movil"].ToString() : "",
                Dsemail = ColumnExists(reader, "dsemail") ? reader["dsemail"].ToString() : "",
                Dseps = ColumnExists(reader, "dseps") ? reader["dseps"].ToString() : "",
                Dsarl = ColumnExists(reader, "dsarl") ? reader["dsarl"].ToString() : "",
                FeregistroPaciente = Convert.ToDateTime(reader["FeregistroPaciente"] != DBNull.Value ? reader["FeregistroPaciente"] : null),
                FebajaPaciente = Convert.ToDateTime(reader["FebajaPaciente"] != DBNull.Value ? reader["FebajaPaciente"] : null),
                CdusuarioPaciente = ColumnExists(reader, "CdusuarioPaciente") ? reader["CdusuarioPaciente"].ToString() : "",
                Dscondicion = ColumnExists(reader, "dscondicion") ? reader["dscondicion"].ToString() : "",
            };
        }

        public async Task<IEnumerable<Respuestas>> updatepatients(PatientsDto Datos)
        {
            using (SqlConnection sql = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_update_patients", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nmind_persona", (Datos.NmindPersona is null) ? (object)DBNull.Value : Datos.NmindPersona));
                    cmd.Parameters.Add(new SqlParameter("@eps", (Datos.Dseps is null) ? (object)DBNull.Value : Datos.Dseps));
                    cmd.Parameters.Add(new SqlParameter("@arl", (Datos.Dsarl is null) ? (object)DBNull.Value : Datos.Dsarl));
                    cmd.Parameters.Add(new SqlParameter("@usuario", (Datos.Cdusuario is null) ? (object)DBNull.Value : Datos.Cdusuario));
                    cmd.Parameters.Add(new SqlParameter("@condicion", (Datos.Dscondicion is null) ? (object)DBNull.Value : Datos.Dscondicion));
                    cmd.Parameters.Add(new SqlParameter("@darBaja", (Datos.darBaja is null) ? (object)DBNull.Value : Datos.darBaja));

                    try
                    {
                        await sql.OpenAsync();
                        var List = new List<Respuestas>();

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            { List.Add(Recorrerupdatepatients(reader)); }
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
        private Respuestas Recorrerupdatepatients(SqlDataReader reader)
        {
            return new Respuestas()
            {
                respuesta = ColumnExists(reader, "Respuesta") ? reader["Respuesta"].ToString() : ""
            };
        }

    }
}
