using Core.Prueba.Entities;
using Infraestructure.Prueba.BDatos.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Prueba.BDatos
{
    public partial class PRUEBAContext : DbContext
    {
        public PRUEBAContext()
        {
        }

        public PRUEBAContext(DbContextOptions<PRUEBAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DataMaestra> DataMaestras { get; set; } = null!;
        public virtual DbSet<Maestra> Maestras { get; set; } = null!;
        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MasterdataConfig());
            modelBuilder.ApplyConfiguration(new PatientsConfig());
            modelBuilder.ApplyConfiguration(new PeopleConfig());
            modelBuilder.ApplyConfiguration(new MasterConfig());
        }
    }
}
