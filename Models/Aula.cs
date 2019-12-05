using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class Aula
    {
        public Aula()
        {
            AlumnoAula = new HashSet<AlumnoAula>();
            MatriculaCursoAula = new HashSet<MatriculaCursoAula>();
        }

        public int AulaId { get; set; }
        public string CodigoAula { get; set; }
        public int? CapacidadMax { get; set; }
        public int? EstadoId { get; set; }

        public virtual ICollection<AlumnoAula> AlumnoAula { get; set; }
        public virtual ICollection<MatriculaCursoAula> MatriculaCursoAula { get; set; }
    }
}
