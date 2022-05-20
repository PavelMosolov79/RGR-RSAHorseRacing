using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Final
{
    public partial class BDContext : DbContext
    {
        public BDContext()
        {
        }

        public BDContext(DbContextOptions<BDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Horse> Horses { get; set; } = null!;
        public virtual DbSet<Jockey> Jockeys { get; set; } = null!;
        public virtual DbSet<JockeyToHorse> JockeyToHorses { get; set; } = null!;
        public virtual DbSet<Owner> Owners { get; set; } = null!;
        public virtual DbSet<OwnerToHorse> OwnerToHorses { get; set; } = null!;
        public virtual DbSet<Result> Results { get; set; } = null!;
        public virtual DbSet<Trainer> Trainers { get; set; } = null!;
        public virtual DbSet<TrainerToHorse> TrainerToHorses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\Pavel\\Desktop\\NEW_BASE\\Final\\Final\\BD.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Horse>(entity =>
            {
                entity.ToTable("HORSE");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasColumnType("STRING");

                entity.Property(e => e.ResultId).HasColumnName("RESULT_ID");

                entity.HasOne(d => d.Result)
                    .WithMany(p => p.Horses)
                    .HasForeignKey(d => d.ResultId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Jockey>(entity =>
            {
                entity.ToTable("Jockey");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasColumnType("STRING");
            });

            modelBuilder.Entity<JockeyToHorse>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Jockey_to_Horse");

                entity.Property(e => e.HorseId).HasColumnName("HORSE_ID");

                entity.Property(e => e.JockeyId).HasColumnName("JOCKEY_ID");

                entity.HasOne(d => d.Horse)
                    .WithMany()
                    .HasForeignKey(d => d.HorseId);

                entity.HasOne(d => d.Jockey)
                    .WithMany()
                    .HasForeignKey(d => d.JockeyId);
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.ToTable("Owner");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasColumnType("STRING");
            });

            modelBuilder.Entity<OwnerToHorse>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Owner_to_Horse");

                entity.Property(e => e.HorseId).HasColumnName("HORSE_ID");

                entity.Property(e => e.OwnerId).HasColumnName("Owner_ID");

                entity.HasOne(d => d.Horse)
                    .WithMany()
                    .HasForeignKey(d => d.HorseId);

                entity.HasOne(d => d.Owner)
                    .WithMany()
                    .HasForeignKey(d => d.OwnerId);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.ToTable("Result");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Place)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("Place%");

                entity.Property(e => e.TotalStake).HasColumnName("Total Stake");

                entity.Property(e => e.Win)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("Win%");

                entity.Property(e => e.WinStake).HasColumnName("Win Stake");

                entity.Property(e => e._2nd).HasColumnName("2nd");

                entity.Property(e => e._3nd).HasColumnName("3nd");
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.ToTable("Trainer");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name).HasColumnType("STRING");
            });

            modelBuilder.Entity<TrainerToHorse>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Trainer_to_horse");

                entity.Property(e => e.HorseId).HasColumnName("Horse_ID");

                entity.Property(e => e.TrainerId).HasColumnName("Trainer_ID");

                entity.HasOne(d => d.Horse)
                    .WithMany()
                    .HasForeignKey(d => d.HorseId);

                entity.HasOne(d => d.Trainer)
                    .WithMany()
                    .HasForeignKey(d => d.TrainerId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
