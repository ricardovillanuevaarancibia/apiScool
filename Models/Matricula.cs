﻿using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class Matricula
    {
        public Matricula()
        {
            MatriculaAula = new HashSet<MatriculaAula>();
            MatriculaCursoProfesor = new HashSet<MatriculaCursoProfesor>();
        }

        public int MatriculaId { get; set; }
        public string CodigoMatricula { get; set; }
        public int? AlumnoId { get; set; }
        public int? GradoAcademicoId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? EstadoId { get; set; }

        public virtual Alumno Alumno { get; set; }
        public virtual GradoAcademico GradoAcademico { get; set; }
        public virtual ICollection<MatriculaAula> MatriculaAula { get; set; }
        public virtual ICollection<MatriculaCursoProfesor> MatriculaCursoProfesor { get; set; }
    }
}
