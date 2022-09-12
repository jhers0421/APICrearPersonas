using Core.Prueba.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Prueba.BDatos.Configurations
{
    public class MasterConfig : IEntityTypeConfiguration<Maestra>
    {
        public void Configure(EntityTypeBuilder<Maestra> builder)
        {
            builder.HasKey(e => e.Nmmaestro);

            builder.Property(e => e.Nmmaestro)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nmmaestro");

            builder.Property(e => e.Cdmaestro)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("cdmaestro");

            builder.Property(e => e.Dsmaestro)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("dsmaestro");

            builder.Property(e => e.Febaja)
                .HasColumnType("datetime")
                .HasColumnName("febaja");

            builder.Property(e => e.Feregistro)
                .HasColumnType("datetime")
                .HasColumnName("feregistro");
        }
    }
}
