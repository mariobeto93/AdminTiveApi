using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AdminTiveDatos.AdminTiveModel
{
    public partial class AdminTiveWebContext : DbContext
    {
        public AdminTiveWebContext()
        {
        }

        public AdminTiveWebContext(DbContextOptions<AdminTiveWebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatSesionesFotografia> CatSesionesFotografias { get; set; }
        public virtual DbSet<CatSesionesGenero> CatSesionesGeneros { get; set; }
        public virtual DbSet<CatSesionesModulo> CatSesionesModulos { get; set; }
        public virtual DbSet<CatSesionesPerfile> CatSesionesPerfiles { get; set; }
        public virtual DbSet<CatSesionesPermiso> CatSesionesPermisos { get; set; }
        public virtual DbSet<CatSesionesSubModulo> CatSesionesSubModulos { get; set; }
        public virtual DbSet<CatSesionesUsuario> CatSesionesUsuarios { get; set; }
        public virtual DbSet<TraSesionesInicioSesion> TraSesionesInicioSesions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AdminTiveWeb;User=Sql_user;Password=Us3r");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CatSesionesFotografia>(entity =>
            {
                entity.ToTable("Cat_Sesiones_Fotografias", "SIS");

                entity.Property(e => e.Foto).IsRequired();

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.CatSesionesFotografia)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Cat_Sesio__Usuar__08B54D69");
            });

            modelBuilder.Entity<CatSesionesGenero>(entity =>
            {
                entity.HasKey(e => e.GeneroId)
                    .HasName("PK__Cat_Sesi__A99D02680C531D75");

                entity.ToTable("Cat_Sesiones_Generos", "SIS");

                entity.Property(e => e.GeneroId).HasColumnName("GeneroID");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatSesionesModulo>(entity =>
            {
                entity.HasKey(e => e.ModuloId)
                    .HasName("PK__Cat_Sesi__26CEB88F14B67754");

                entity.ToTable("Cat_Sesiones_Modulos", "SIS");

                entity.Property(e => e.ModuloId).HasColumnName("ModuloID");

                entity.Property(e => e.Modulo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatSesionesPerfile>(entity =>
            {
                entity.HasKey(e => e.PerfilId)
                    .HasName("PK__Cat_Sesi__0C005B66D63C6645");

                entity.ToTable("Cat_Sesiones_Perfiles", "SIS");

                entity.Property(e => e.PerfilId).HasColumnName("PerfilID");

                entity.Property(e => e.Perfil)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatSesionesPermiso>(entity =>
            {
                entity.HasKey(e => e.PermisoId)
                    .HasName("PK__Cat_Sesi__96E0C70334FBF04B");

                entity.ToTable("Cat_Sesiones_Permisos", "SIS");

                entity.Property(e => e.PermisoId).HasColumnName("PermisoID");

                entity.Property(e => e.PerfilId).HasColumnName("PerfilID");

                entity.Property(e => e.SubModuloId).HasColumnName("SubModuloID");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.CatSesionesPermisos)
                    .HasForeignKey(d => d.PerfilId)
                    .HasConstraintName("FK__Cat_Sesio__Perfi__6FE99F9F");

                entity.HasOne(d => d.SubModulo)
                    .WithMany(p => p.CatSesionesPermisos)
                    .HasForeignKey(d => d.SubModuloId)
                    .HasConstraintName("FK__Cat_Sesio__SubMo__6EF57B66");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.CatSesionesPermisos)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Cat_Sesio__Usuar__70DDC3D8");
            });

            modelBuilder.Entity<CatSesionesSubModulo>(entity =>
            {
                entity.HasKey(e => e.SubModuloId)
                    .HasName("PK__Cat_Sesi__773A978AE408F1F5");

                entity.ToTable("Cat_Sesiones_SubModulos", "SIS");

                entity.Property(e => e.SubModuloId).HasColumnName("SubModuloID");

                entity.Property(e => e.Controlador)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ModuloId).HasColumnName("ModuloID");

                entity.Property(e => e.SubModulo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("url");

                entity.HasOne(d => d.Modulo)
                    .WithMany(p => p.CatSesionesSubModulos)
                    .HasForeignKey(d => d.ModuloId)
                    .HasConstraintName("FK__Cat_Sesio__Modul__6754599E");
            });

            modelBuilder.Entity<CatSesionesUsuario>(entity =>
            {
                entity.HasKey(e => e.UsuarioId)
                    .HasName("PK__Cat_Sesi__2B3DE7980A6BD709");

                entity.ToTable("Cat_Sesiones_Usuarios", "SIS");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.Property(e => e.ApellidoM)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoP)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PerfilId).HasColumnName("PerfilID");

                entity.Property(e => e.SecionActiva).HasDefaultValueSql("((0))");

                entity.Property(e => e.UltimoEvento)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.CatSesionesUsuarios)
                    .HasForeignKey(d => d.PerfilId)
                    .HasConstraintName("FK__Cat_Sesio__Perfi__6C190EBB");
            });

            modelBuilder.Entity<TraSesionesInicioSesion>(entity =>
            {
                entity.HasKey(e => e.SesionId)
                    .HasName("PK__Tra_Sesi__52FD7C0650327111");

                entity.ToTable("Tra_Sesiones_InicioSesion", "SIS");

                entity.Property(e => e.SesionId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SesionID");

                entity.Property(e => e.FechaHora).HasColumnType("datetime");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.TraSesionesInicioSesions)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Tra_Sesio__Usuar__02FC7413");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
