using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class Examen
    {
        public Examen()
        {
            Nota = new HashSet<Nota>();
        }

        public int ExamenId { get; set; }
        public int? GradoAcademicoCursoId { get; set; }
        public DateTime? FechaExamen { get; set; }
        public int? TipoExamenId { get; set; }
        public int? EstadoId { get; set; }

        public virtual GradoAcademicoCurso GradoAcademicoCurso { get; set; }
        public virtual TipoGenerico TipoExamen { get; set; }
        public virtual ICollection<Nota> Nota { get; set; }
    }
}
