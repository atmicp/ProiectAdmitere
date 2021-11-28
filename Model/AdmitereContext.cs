using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Admitere3.Model
{
    public partial class AdmitereContext : DbContext
    {
        public AdmitereContext()
        {
        }

        public AdmitereContext(DbContextOptions<AdmitereContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Beneficiari> Beneficiaris { get; set; }
        public virtual DbSet<BeneficiariProgrameDeStudii> BeneficiariProgrameDeStudiis { get; set; }
        public virtual DbSet<DateCandidati> DateCandidatis { get; set; }
        public virtual DbSet<ProgrameDeStudiu> ProgrameDeStudius { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Beneficiari>(entity =>
            {
                entity.HasKey(e => e.IdBeneficiar);

                entity.ToTable("Beneficiari");

                entity.Property(e => e.Denumire)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<BeneficiariProgrameDeStudii>(entity =>
            {
                entity.HasKey(e => new { e.IdBeneficiar, e.IdProgrameDeStudiu });

                entity.ToTable("Beneficiari_ProgrameDeStudii");

                entity.HasOne(d => d.IdBeneficiarNavigation)
                    .WithMany(p => p.BeneficiariProgrameDeStudiis)
                    .HasForeignKey(d => d.IdBeneficiar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Beneficiari_ProgrameDeStudii_Beneficiari");

                entity.HasOne(d => d.IdProgrameDeStudiuNavigation)
                    .WithMany(p => p.BeneficiariProgrameDeStudiis)
                    .HasForeignKey(d => d.IdProgrameDeStudiu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Beneficiari_ProgrameDeStudii_ProgrameDeStudiu");
            });

            modelBuilder.Entity<DateCandidati>(entity =>
            {
                entity.HasKey(e => e.IdCandidat);

                entity.ToTable("DateCandidati");

                entity.Property(e => e.Apartament)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Bloc)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Cnp)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("CNP")
                    .IsFixedLength(true);

                entity.Property(e => e.DataNasterii).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Etaj)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Judet)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Localitatea)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LoculNasterii)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NumarCi)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("NumarCI");

                entity.Property(e => e.Nume)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Pdf)
                    .IsRequired()
                    .HasColumnName("PDF");

                entity.Property(e => e.PrenumeCandidat)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PrenumeTata)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Scara)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Sector).HasMaxLength(100);

                entity.Property(e => e.SerieCi)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("SerieCI");

                entity.Property(e => e.Strada)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Telefon)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdBeneficiarNavigation)
                    .WithMany(p => p.DateCandidatis)
                    .HasForeignKey(d => d.IdBeneficiar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DateCandidati_Beneficiari");
            });

            modelBuilder.Entity<ProgrameDeStudiu>(entity =>
            {
                entity.HasKey(e => e.IdProgramDeStudiu);

                entity.ToTable("ProgrameDeStudiu");

                entity.Property(e => e.Denumire)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
