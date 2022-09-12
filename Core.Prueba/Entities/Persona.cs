namespace Core.Prueba.Entities
{
    public partial class Persona
    {
        public Persona()
        {
            Pacientes = new HashSet<Paciente>();
        }

        public int Nmid { get; set; }
        public string? Cddocumento { get; set; }
        public string? Dsnombres { get; set; }
        public string? Dsapellidos { get; set; }
        public DateTime? Fenacimiento { get; set; }
        public string? Cdtipo { get; set; }
        public string? Cdgenero { get; set; }
        public DateTime? Feregistro { get; set; }
        public DateTime? Febaja { get; set; }
        public string? Cdusuario { get; set; }
        public string? Dsdireccion { get; set; }
        public byte[]? Dsphoto { get; set; }
        public string? CdtelefonoFijo { get; set; }
        public string? CdtelefonoMovil { get; set; }
        public string? Dsemail { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
