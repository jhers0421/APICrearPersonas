namespace Core.Prueba.Entities
{
    public partial class Paciente
    {
        public int Nmind { get; set; }
        public int? NmindPersona { get; set; }
        public int? NimdMedicotra { get; set; }
        public string? Dseps { get; set; }
        public string? Dsarl { get; set; }
        public DateTime? Feregistro { get; set; }
        public DateTime? Febaja { get; set; }
        public string? Cdusuario { get; set; }
        public string? Dscondicion { get; set; }

        public virtual Persona? NmindPersonaNavigation { get; set; }
    }
}
