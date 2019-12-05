using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class GradoAcademico
    {
        public GradoAcademico()
        {
            GradoAcademicoCurso = new HashSet<GradoAcademicoCurso>();
            Horario = new HashSet<Horario>();
            Matricula = new HashSet<Matricula>();
        }

        public int GradoAcademicoId { get; set; }
        public string Nombre { get; set; }
        public int? EstadoId { get; set; }

        public virtual ICollection<GradoAcademicoCurso> GradoAcademicoCurso { get; set; }
        public virtual ICollection<Horario> Horario { get; set; }
        public virtual ICollection<Matricula> Matricula { get; set; }
    }
}
