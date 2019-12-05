using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class Asistencia
    {
        public int AsistenciaId { get; set; }
        public int? AlumnoId { get; set; }
        public DateTime? FechaAsistencia { get; set; }
        public int? EstadoId { get; set; }

        public virtual Alumno Alumno { get; set; }
    }
}
