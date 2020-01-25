using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class Horario
    {
        public int HorarioId { get; set; }
        public int? GradoAcademicoId { get; set; }
        public int? CursoId { get; set; }
        public DateTime? LunesHoraInicio { get; set; }
        public DateTime? LunesHoraFin { get; set; }
        public DateTime? MartesHoraInicio { get; set; }
        public DateTime? MartesHoraFin { get; set; }
        public DateTime? MiercolesHoraInicio { get; set; }
        public DateTime? MiercolesHoraFin { get; set; }
        public DateTime? JuevesHoraInicio { get; set; }
        public DateTime? JuevesHoraFin { get; set; }
        public DateTime? ViernesHoraInicio { get; set; }
        public DateTime? ViernesHoraFin { get; set; }
        public DateTime? SabadoHoraInicio { get; set; }
        public DateTime? SabadoHoraFin { get; set; }
        public DateTime? DomingoHoraInicio { get; set; }
        public DateTime? DomingoHoraFin { get; set; }
        public bool? Lunes { get; set; }
        public bool? Martes { get; set; }
        public bool? Miercoles { get; set; }
        public bool? Jueves { get; set; }
        public bool? Viernes { get; set; }
        public bool? Sabado { get; set; }
        public bool? Domingo { get; set; }
        public int EstadoId { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual GradoAcademico GradoAcademico { get; set; }
    }
}
