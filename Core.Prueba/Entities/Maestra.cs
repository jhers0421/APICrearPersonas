namespace Core.Prueba.Entities
{
    public partial class Maestra
    {
        public Maestra()
        {
            DataMaestras = new HashSet<DataMaestra>();
        }

        public string Nmmaestro { get; set; } = null!;
        public string? Cdmaestro { get; set; }
        public string? Dsmaestro { get; set; }
        public DateTime? Feregistro { get; set; }
        public DateTime? Febaja { get; set; }

        public virtual ICollection<DataMaestra> DataMaestras { get; set; }
    }
}
