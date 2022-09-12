using Core.Prueba.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Prueba.BDatos.Configurations
{
    public class PatientsConfig : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(e => e.Nmind);

            builder.Property(e => e.Nmind).HasColumnName("nmind");

            builder.Property(e => e.Cdusuario)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("cdusuario");

            builder.Property(e => e.Dsarl)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dsarl");

            builder.Property(e => e.Dscondicion)
                .HasColumnType("text")
                .HasColumnName("dscondicion");

            builder.Property(e => e.Dseps)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dseps");

            builder.Property(e => e.Febaja)
                .HasColumnType("datetime")
                .HasColumnName("febaja");

            builder.Property(e => e.Feregistro)
                .HasColumnType("datetime")
                .HasColumnName("feregistro");

            builder.Property(e => e.NimdMedicotra).HasColumnName("nimd_medicotra");

            builder.Property(e => e.NmindPersona).HasColumnName("nmind_persona");

            builder.HasOne(d => d.NmindPersonaNavigation)
                .WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.NmindPersona)
                .HasConstraintName("FK_Pacientes_Personas");
        }
    }
}
