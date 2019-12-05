using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class Curso
    {
        public Curso()
        {
            GradoAcademicoCurso = new HashSet<GradoAcademicoCurso>();
            Horario = new HashSet<Horario>();
        }

        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public int EstadoId { get; set; }

        public virtual ICollection<GradoAcademicoCurso> GradoAcademicoCurso { get; set; }
        public virtual ICollection<Horario> Horario { get; set; }
    }
}
