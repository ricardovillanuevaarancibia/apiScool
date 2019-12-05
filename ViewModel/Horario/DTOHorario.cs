using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiScool.ViewModel.Horario
{
    public class DTOHorario
    {
        public int ? HorarioId { get; set; }
        public int GradoAcademicoId { get; set; }
        public int CursoId { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public bool ? Lunes { get; set; }
        public bool ? Martes { get; set; }
        public bool ? Miercoles { get; set; }
        public bool ? Jueves { get; set; }
        public bool ? Viernes { get; set; }
        public bool ? Sabado { get; set; }
        public bool ? Domingo { get; set; }
        public int EstadoId { get; set; }
    }
}
