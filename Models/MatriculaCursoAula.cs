using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class MatriculaCursoAula
    {
        public int MatriculaCursoAulaId { get; set; }
        public int? MatriculaCursoId { get; set; }
        public int? AulaId { get; set; }
        public int? EstadoId { get; set; }

        public virtual Aula Aula { get; set; }
        public virtual GradoAcademicoCurso MatriculaCurso { get; set; }
    }
}
