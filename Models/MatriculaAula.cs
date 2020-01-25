using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class MatriculaAula
    {
        public int MatriculaCursoAulaId { get; set; }
        public int? MatriculaId { get; set; }
        public int? CursoId { get; set; }
        public int? AulaId { get; set; }
        public int? EstadoId { get; set; }

        public virtual Aula Aula { get; set; }
        public virtual Matricula Matricula { get; set; }
    }
}
