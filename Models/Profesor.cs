using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class Profesor
    {
        public Profesor()
        {
            GradoAcademicoCurso = new HashSet<GradoAcademicoCurso>();
            MatriculaCursoProfesor = new HashSet<MatriculaCursoProfesor>();
        }

        public int ProfesorId { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Dni { get; set; }
        public int? EstadoId { get; set; }
        public string RutaFoto { get; set; }

        public virtual ICollection<GradoAcademicoCurso> GradoAcademicoCurso { get; set; }
        public virtual ICollection<MatriculaCursoProfesor> MatriculaCursoProfesor { get; set; }
    }
}
