using Core.Prueba.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Prueba.BDatos.Configurations
{
    public class PeopleConfig : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(e => e.Nmid);

            builder.Property(e => e.Nmid).HasColumnName("nmid");

            builder.Property(e => e.Cddocumento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cddocumento");

            builder.Property(e => e.Cdgenero)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cdgenero");

            builder.Property(e => e.CdtelefonoFijo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cdtelefono_fijo");

            builder.Property(e => e.CdtelefonoMovil)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cdtelefono_movil");

            builder.Property(e => e.Cdtipo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cdtipo");

            builder.Property(e => e.Cdusuario)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("cdusuario");

            builder.Property(e => e.Dsapellidos)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("dsapellidos");

            builder.Property(e => e.Dsdireccion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("dsdireccion");

            builder.Property(e => e.Dsemail)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("dsemail");

            builder.Property(e => e.Dsnombres)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("dsnombres");

            builder.Property(e => e.Dsphoto).HasColumnName("dsphoto");

            builder.Property(e => e.Febaja)
                .HasColumnType("datetime")
                .HasColumnName("febaja");

            builder.Property(e => e.Fenacimiento)
                .HasColumnType("date")
                .HasColumnName("fenacimiento");

            builder.Property(e => e.Feregistro)
                .HasColumnType("datetime")
                .HasColumnName("feregistro");
        }
    }
}
