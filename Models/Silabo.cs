using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class Silabo
    {
        public int SilabosId { get; set; }
        public int? CursoGradoAcademicoId { get; set; }
        public int? EstadoId { get; set; }

        public virtual GradoAcademicoCurso CursoGradoAcademico { get; set; }
    }
}
