using Core.Prueba.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Prueba.BDatos.Configurations
{
    public class MasterdataConfig : IEntityTypeConfiguration<DataMaestra>
    {
        public void Configure(EntityTypeBuilder<DataMaestra> builder)
        {
            builder.HasKey(e => e.Nmdato);

            builder.ToTable("DataMaestra");

            builder.Property(e => e.Nmdato)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nmdato");

            builder.Property(e => e.Cddato)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cddato");

            builder.Property(e => e.Cddato1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cddato1");

            builder.Property(e => e.Cddato2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cddato2");

            builder.Property(e => e.Cddato3)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cddato3");

            builder.Property(e => e.Dsdato)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("dsdato");

            builder.Property(e => e.Febaja)
                .HasColumnType("datetime")
                .HasColumnName("febaja");

            builder.Property(e => e.Feregistro)
                .HasColumnType("datetime")
                .HasColumnName("feregistro");

            builder.Property(e => e.Nmaestro)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nmaestro");

            builder.HasOne(d => d.NmaestroNavigation)
                .WithMany(p => p.DataMaestras)
                .HasForeignKey(d => d.Nmaestro)
                .HasConstraintName("FK_DataMaestra_Maestras");
        }
    }
}
