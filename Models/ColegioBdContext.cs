using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiScool.Models
{
    public partial class ColegioBdContext : DbContext
    {
        public ColegioBdContext()
        {
        }

        public ColegioBdContext(DbContextOptions<ColegioBdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividades> Actividades { get; set; }
        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<AlumnoAula> AlumnoAula { get; set; }
        public virtual DbSet<Asistencia> Asistencia { get; set; }
        public virtual DbSet<Aula> Aula { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Examen> Examen { get; set; }
        public virtual DbSet<GradoAcademico> GradoAcademico { get; set; }
        public virtual DbSet<GradoAcademicoCurso> GradoAcademicoCurso { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<MatriculaAula> MatriculaAula { get; set; }
        public virtual DbSet<MatriculaCursoProfesor> MatriculaCursoProfesor { get; set; }
        public virtual DbSet<Nota> Nota { get; set; }
        public virtual DbSet<Notificacion> Notificacion { get; set; }
        public virtual DbSet<NotificacionRespuesta> NotificacionRespuesta { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }
        public virtual DbSet<Silabo> Silabo { get; set; }
        public virtual DbSet<TipoGenerico> TipoGenerico { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioAlumno> UsuarioAlumno { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ColegioBd;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividades>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RutaFoto)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AlumnoAula>(entity =>
            {
                entity.HasOne(d => d.Alumno)
                    .WithMany(p => p.AlumnoAula)
                    .HasForeignKey(d => d.AlumnoId)
                    .HasConstraintName("FK_AlumnoAula_Alumno");

                entity.HasOne(d => d.Aula)
                    .WithMany(p => p.AlumnoAula)
                    .HasForeignKey(d => d.AulaId)
                    .HasConstraintName("FK_AlumnoAula_Aula");
            });

            modelBuilder.Entity<Asistencia>(entity =>
            {
                entity.Property(e => e.FechaAsistencia).HasColumnType("datetime");

                entity.HasOne(d => d.Alumno)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.AlumnoId)
                    .HasConstraintName("FK_Asistencia_Alumno");
            });

            modelBuilder.Entity<Aula>(entity =>
            {
                entity.Property(e => e.CodigoAula)
                    .HasMaxLength(8)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.Property(e => e.Image)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.Property(e => e.EstadoId).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Examen>(entity =>
            {
                entity.Property(e => e.FechaExamen).HasColumnType("datetime");

                entity.HasOne(d => d.GradoAcademicoCurso)
                    .WithMany(p => p.Examen)
                    .HasForeignKey(d => d.GradoAcademicoCursoId)
                    .HasConstraintName("FK_Examen_GradoAcademicoCursoId");

                entity.HasOne(d => d.TipoExamen)
                    .WithMany(p => p.Examen)
                    .HasForeignKey(d => d.TipoExamenId)
                    .HasConstraintName("FK_Examen_TipoExamen");
            });

            modelBuilder.Entity<GradoAcademico>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GradoAcademicoCurso>(entity =>
            {
                entity.Property(e => e.Silabos)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.GradoAcademicoCurso)
                    .HasForeignKey(d => d.CursoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatriculaCurso_Curso");

                entity.HasOne(d => d.GradoAcademico)
                    .WithMany(p => p.GradoAcademicoCurso)
                    .HasForeignKey(d => d.GradoAcademicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatriculaCurso_GradoAcademico");

                entity.HasOne(d => d.Profesor)
                    .WithMany(p => p.GradoAcademicoCurso)
                    .HasForeignKey(d => d.ProfesorId)
                    .HasConstraintName("FK_GradoAcademicoCurso_Profesor");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.Property(e => e.DomingoHoraFin)
                    .HasColumnName("DomingoHoraFIn")
                    .HasColumnType("datetime");

                entity.Property(e => e.DomingoHoraInicio).HasColumnType("datetime");

                entity.Property(e => e.JuevesHoraFin).HasColumnType("datetime");

                entity.Property(e => e.JuevesHoraInicio).HasColumnType("datetime");

                entity.Property(e => e.LunesHoraFin).HasColumnType("datetime");

                entity.Property(e => e.LunesHoraInicio).HasColumnType("datetime");

                entity.Property(e => e.MartesHoraFin).HasColumnType("datetime");

                entity.Property(e => e.MartesHoraInicio).HasColumnType("datetime");

                entity.Property(e => e.MiercolesHoraFin).HasColumnType("datetime");

                entity.Property(e => e.MiercolesHoraInicio).HasColumnType("datetime");

                entity.Property(e => e.SabadoHoraFin).HasColumnType("datetime");

                entity.Property(e => e.SabadoHoraInicio).HasColumnType("datetime");

                entity.Property(e => e.ViernesHoraFin).HasColumnType("datetime");

                entity.Property(e => e.ViernesHoraInicio).HasColumnType("datetime");

                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.Horario)
                    .HasForeignKey(d => d.CursoId)
                    .HasConstraintName("FK_Horario_Curso");

                entity.HasOne(d => d.GradoAcademico)
                    .WithMany(p => p.Horario)
                    .HasForeignKey(d => d.GradoAcademicoId)
                    .HasConstraintName("FK_Horario_GradoAcademico");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.Property(e => e.CodigoMatricula)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.HasOne(d => d.Alumno)
                    .WithMany(p => p.Matricula)
                    .HasForeignKey(d => d.AlumnoId)
                    .HasConstraintName("FK_Matricula");

                entity.HasOne(d => d.GradoAcademico)
                    .WithMany(p => p.Matricula)
                    .HasForeignKey(d => d.GradoAcademicoId)
                    .HasConstraintName("FK_Matricula_GradoAcademico");
            });

            modelBuilder.Entity<MatriculaAula>(entity =>
            {
                entity.HasKey(e => e.MatriculaCursoAulaId)
                    .HasName("PK_MatriculaCursoAula");

                entity.HasOne(d => d.Aula)
                    .WithMany(p => p.MatriculaAula)
                    .HasForeignKey(d => d.AulaId)
                    .HasConstraintName("FK_MatriculaCursoAula_Aula");

                entity.HasOne(d => d.Matricula)
                    .WithMany(p => p.MatriculaAula)
                    .HasForeignKey(d => d.MatriculaId)
                    .HasConstraintName("FK_MatriculaCursoAula_Matricula");
            });

            modelBuilder.Entity<MatriculaCursoProfesor>(entity =>
            {
                entity.HasOne(d => d.Curso)
                    .WithMany(p => p.MatriculaCursoProfesor)
                    .HasForeignKey(d => d.CursoId)
                    .HasConstraintName("FK_MatriculaCursoProfesor_Curso");

                entity.HasOne(d => d.Matricula)
                    .WithMany(p => p.MatriculaCursoProfesor)
                    .HasForeignKey(d => d.MatriculaId)
                    .HasConstraintName("FK_MatriculaCursoProfesor_Matricula");

                entity.HasOne(d => d.Profesor)
                    .WithMany(p => p.MatriculaCursoProfesor)
                    .HasForeignKey(d => d.ProfesorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatriculaCursoProfesor_Profesor");
            });

            modelBuilder.Entity<Nota>(entity =>
            {
                entity.Property(e => e.Nota1)
                    .HasColumnName("Nota")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.NotaAlfabeto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Alumno)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.AlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Nota_Alumno");

                entity.HasOne(d => d.Examen)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.ExamenId)
                    .HasConstraintName("FK_Nota_Examen");

                entity.HasOne(d => d.TipoNota)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.TipoNotaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Nota_TipoNota");
            });

            modelBuilder.Entity<Notificacion>(entity =>
            {
                entity.Property(e => e.Comentario)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoNotificacion)
                    .WithMany(p => p.Notificacion)
                    .HasForeignKey(d => d.TipoNotificacionId)
                    .HasConstraintName("FK_Notificacion_TipoNotificacion");

                entity.HasOne(d => d.UsuarioSend)
                    .WithMany(p => p.Notificacion)
                    .HasForeignKey(d => d.UsuarioSendId)
                    .HasConstraintName("FK_Notificacion_Usuario");
            });

            modelBuilder.Entity<NotificacionRespuesta>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Mensaje).HasColumnType("text");

                entity.HasOne(d => d.Notificacion)
                    .WithMany(p => p.NotificacionRespuesta)
                    .HasForeignKey(d => d.NotificacionId)
                    .HasConstraintName("FK_NotificacionRespuesta_Notificacion");
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.Property(e => e.Observacion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Alumno)
                    .WithMany(p => p.Permiso)
                    .HasForeignKey(d => d.AlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permiso_Alumno");

                entity.HasOne(d => d.TipoPermiso)
                    .WithMany(p => p.Permiso)
                    .HasForeignKey(d => d.TipoPermisoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permiso_TipoPermiso");
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RutaFoto)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Silabo>(entity =>
            {
                entity.HasKey(e => e.SilabosId);

                entity.HasOne(d => d.CursoGradoAcademico)
                    .WithMany(p => p.Silabo)
                    .HasForeignKey(d => d.CursoGradoAcademicoId)
                    .HasConstraintName("FK_Silabo_CursoGradoAcademico");
            });

            modelBuilder.Entity<TipoGenerico>(entity =>
            {
                entity.Property(e => e.Entidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoGenericoPadre)
                    .WithMany(p => p.InverseTipoGenericoPadre)
                    .HasForeignKey(d => d.TipoGenericoPadreId)
                    .HasConstraintName("FK_TipoGenerico_TipoGenericoPadre");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rol)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.ApellidosM)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidosP)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsuarioAlumno>(entity =>
            {
                entity.HasOne(d => d.Alumno)
                    .WithMany(p => p.UsuarioAlumno)
                    .HasForeignKey(d => d.AlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioAlumno_Alumno");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.UsuarioAlumno)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioAlumno_Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
