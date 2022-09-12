namespace Core.Prueba.Entities
{
    public partial class DataMaestra
    {
        public string Nmdato { get; set; } = null!;
        public string? Nmaestro { get; set; }
        public string? Cddato { get; set; }
        public string? Dsdato { get; set; }
        public string? Cddato1 { get; set; }
        public string? Cddato2 { get; set; }
        public string? Cddato3 { get; set; }
        public DateTime? Feregistro { get; set; }
        public DateTime? Febaja { get; set; }

        public virtual Maestra? NmaestroNavigation { get; set; }
    }
}
