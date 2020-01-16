using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiScool.ViewModel.Matricula
{
    public class DTOMatricula
    {
        public int MatriculaId { get; set; }
        public string CodigoMatricula { get; set; }
        public int AlumnoId { get; set; }
        public int GradoAcademicoId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int EstadoId { get; set; }

    }
}
