using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class UsuarioAlumno
    {
        public int UsuarioAlumnoId { get; set; }
        public int UsuarioId { get; set; }
        public int AlumnoId { get; set; }

        public virtual Alumno Alumno { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
