namespace Core.Prueba.DTOs
{
    public class PatientsDto
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

        //Agregados
        public bool? darBaja { get; set; }
    }
}
