using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class GradoAcademicoCurso
    {
        public GradoAcademicoCurso()
        {
            Examen = new HashSet<Examen>();
            Silabo = new HashSet<Silabo>();
        }

        public int GradoAcademicoCursoId { get; set; }
        public int CursoId { get; set; }
        public int GradoAcademicoId { get; set; }
        public int EstadoId { get; set; }
        public string Silabos { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual GradoAcademico GradoAcademico { get; set; }
        public virtual ICollection<Examen> Examen { get; set; }
        public virtual ICollection<Silabo> Silabo { get; set; }
    }
}
