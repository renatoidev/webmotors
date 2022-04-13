using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebMotors.Models;

namespace WebMotors.Data.Mapping
{
    public class AdMap : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder.ToTable("tb_AnuncioWebmotors");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Make)
                .HasColumnName("marca")
                .HasColumnType("VARCHAR")
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(x => x.Model)
                .HasColumnName("modelo")
                .HasColumnType("VARCHAR")
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(x => x.Version)
                .HasColumnName("versao")
                .HasColumnType("VARCHAR")
                .HasMaxLength(45)
                .IsRequired();

            builder.Property(x => x.Year)
                .HasColumnName("ano")
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(x => x.Km)
                .HasColumnName("quilometragem")
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(x => x.Note)
                .HasColumnName("observacao")
                .HasColumnType("TEXT")
                .IsRequired();
        }
    }
}
