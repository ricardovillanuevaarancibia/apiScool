using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiScool.ViewModel.Cursos
{
    public class DTOCurso
    {
        public int ? CursoId { get; set; }
        public string Nombre { get; set; }
        public string Image { get; set; }
        public int EstadoId { get; set; }
    }
}
