using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiScool.ViewModel.Profesor
{
    public class DTOProfesor
    {
        public int ? ProfesorId { get; set; }
        public string Nombre { get; set; }
        public string MyProperty { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Dni { get; set; }
        public int EstadoId { get; set; }
    }
}
