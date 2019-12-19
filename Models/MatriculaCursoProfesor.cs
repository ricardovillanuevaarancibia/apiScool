using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class MatriculaCursoProfesor
    {
        public int MatriculaCursoProfesorId { get; set; }
        public int? MatriculaId { get; set; }
        public int? CursoId { get; set; }
        public int ProfesorId { get; set; }
        public int EstadoId { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual Matricula Matricula { get; set; }
        public virtual Profesor Profesor { get; set; }
    }
}
