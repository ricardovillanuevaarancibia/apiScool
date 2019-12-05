using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiScool.ViewModel.Alumnos
{
    public class DTOAlumno
    {
        public int ? AlumnoId { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int EstadoId { get; set; }
    }
}
