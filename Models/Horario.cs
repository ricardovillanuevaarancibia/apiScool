using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class Horario
    {
        public int HorarioId { get; set; }
        public int? GradoAcademicoId { get; set; }
        public int? CursoId { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFin { get; set; }
        public bool Lunes { get; set; }
        public bool Martes { get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }
        public int EstadoId { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual GradoAcademico GradoAcademico { get; set; }
    }
}
