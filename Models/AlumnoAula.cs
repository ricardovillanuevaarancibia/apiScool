using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class AlumnoAula
    {
        public int AlumnoAulaId { get; set; }
        public int? AulaId { get; set; }
        public int? AlumnoId { get; set; }
        public int? EstadoId { get; set; }

        public virtual Alumno Alumno { get; set; }
        public virtual Aula Aula { get; set; }
    }
}
