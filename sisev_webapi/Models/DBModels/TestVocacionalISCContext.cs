using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace sisev_webapi.Models.DBModels
{
    public partial class TestVocacionalISCContext : DbContext
    {
        public TestVocacionalISCContext()
        {
        }

        public TestVocacionalISCContext(DbContextOptions<TestVocacionalISCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarreraMaterias> CarreraMaterias { get; set; }
        public virtual DbSet<Carreras> Carreras { get; set; }
        public virtual DbSet<Materias> Materias { get; set; }
        public virtual DbSet<PesoCarrera> PesoCarrera { get; set; }
        public virtual DbSet<Preguntas> Preguntas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<UsuariosResultado> UsuariosResultado { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=123456789;database=TestVocacionalISC", x => x.ServerVersion("10.4.13-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarreraMaterias>(entity =>
            {
                entity.HasKey(e => e.IdCarreraMateria)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCarrera)
                    .HasName("IdCarrera");

                entity.HasIndex(e => e.IdMateria)
                    .HasName("IdMateria");

                entity.Property(e => e.IdCarreraMateria).HasColumnType("int(11)");

                entity.Property(e => e.IdCarrera).HasColumnType("int(11)");

                entity.Property(e => e.IdMateria).HasColumnType("int(11)");

                entity.Property(e => e.Peso).HasColumnType("int(11)");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.CarreraMaterias)
                    .HasForeignKey(d => d.IdCarrera)
                    .HasConstraintName("CarreraMaterias_ibfk_1");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.CarreraMaterias)
                    .HasForeignKey(d => d.IdMateria)
                    .HasConstraintName("CarreraMaterias_ibfk_2");
            });

            modelBuilder.Entity<Carreras>(entity =>
            {
                entity.HasKey(e => e.IdCarrera)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdCarrera).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Materias>(entity =>
            {
                entity.HasKey(e => e.IdMateria)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdMateria).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<PesoCarrera>(entity =>
            {
                entity.HasKey(e => e.IdPeso)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCarrera)
                    .HasName("IdCarrera");

                entity.Property(e => e.IdPeso).HasColumnType("int(11)");

                entity.Property(e => e.IdCarrera).HasColumnType("int(11)");

                entity.Property(e => e.Peso).HasColumnType("int(11)");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.PesoCarrera)
                    .HasForeignKey(d => d.IdCarrera)
                    .HasConstraintName("PesoCarrera_ibfk_1");
            });

            modelBuilder.Entity<Preguntas>(entity =>
            {
                entity.HasKey(e => e.IdPregunta)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdMateria)
                    .HasName("IdMateria");

                entity.Property(e => e.IdPregunta).HasColumnType("int(11)");

                entity.Property(e => e.IdMateria).HasColumnType("int(11)");

                entity.Property(e => e.Pregunta)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Preguntas)
                    .HasForeignKey(d => d.IdMateria)
                    .HasConstraintName("Preguntas_ibfk_1");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasIndex(e => e.Contrasena)
                    .HasName("Contrasena")
                    .IsUnique();

                entity.HasIndex(e => e.Usuario)
                    .HasName("Usuario")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Contrasena)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Usuario)
                    .HasColumnType("varchar(15)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<UsuariosResultado>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("IdUsuario");

                entity.Property(e => e.IdUsuario).HasColumnType("int(11)");

                entity.Property(e => e.Resultado1)
                    .HasColumnType("varchar(6)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Resultado2)
                    .HasColumnType("varchar(6)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Resultado3)
                    .HasColumnType("varchar(6)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("UsuariosResultado_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
