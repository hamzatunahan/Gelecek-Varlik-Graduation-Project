using System;
using SiteYonetim.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SiteYonetim.Dal.Concrete.EntityFramework.Context
{
    public partial class SıteYonetimContext : DbContext
    {
        public SıteYonetimContext()
        {
        }

        public SıteYonetimContext(DbContextOptions<SıteYonetimContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apartman> Apartmans { get; set; }
        public virtual DbSet<Fatura> Faturas { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=DESKTOP-DCFBJJI;Database=SiteYonetim;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Apartman>(entity =>
            {
                entity.ToTable("Apartman");

                entity.Property(e => e.Tip)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Blok)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.InDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Resident)
                    .WithMany(p => p.Apartmans)
                    .HasForeignKey(d => d.DaireId)
                    .HasConstraintName("FK_Apartman_User");
            });

            modelBuilder.Entity<Fatura>(entity =>
            {
                entity.ToTable("Fatura");

                entity.Property(e => e.FaturaTipi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OdemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.PaymentDueDate).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Payer)
                    .WithMany(p => p.Faturas)
                    .HasForeignKey(d => d.PayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fatura_User");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.InDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MessageIcerik)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.MessageReceivers)
                    .HasForeignKey(d => d.AlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_User");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.MessageSenders)
                    .HasForeignKey(d => d.GonderenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_User1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TCNo)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.InDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpDateTime).HasColumnType("datetime");

                entity.Property(e => e.Plaka).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
