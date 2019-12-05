using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class MatriculaCursoProfesor
    {
        public int MatriculaCursoProfesorId { get; set; }
        public int? MatriculaCursoId { get; set; }
        public int ProfesorId { get; set; }
        public int EstadoId { get; set; }

        public virtual GradoAcademicoCurso MatriculaCurso { get; set; }
        public virtual Profesor Profesor { get; set; }
    }
}
