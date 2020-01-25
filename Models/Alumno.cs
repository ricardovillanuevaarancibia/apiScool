using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class Alumno
    {
        public Alumno()
        {
            AlumnoAula = new HashSet<AlumnoAula>();
            Asistencia = new HashSet<Asistencia>();
            Matricula = new HashSet<Matricula>();
            Nota = new HashSet<Nota>();
            Permiso = new HashSet<Permiso>();
            UsuarioAlumno = new HashSet<UsuarioAlumno>();
        }

        public int AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Dni { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int EstadoId { get; set; }
        public string RutaFoto { get; set; }

        public virtual ICollection<AlumnoAula> AlumnoAula { get; set; }
        public virtual ICollection<Asistencia> Asistencia { get; set; }
        public virtual ICollection<Matricula> Matricula { get; set; }
        public virtual ICollection<Nota> Nota { get; set; }
        public virtual ICollection<Permiso> Permiso { get; set; }
        public virtual ICollection<UsuarioAlumno> UsuarioAlumno { get; set; }
    }
}
