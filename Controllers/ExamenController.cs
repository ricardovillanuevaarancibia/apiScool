﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiScool.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiScool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamenController : ControllerBase
    {
        private ScoolBdContext Context;
        public ExamenController(ScoolBdContext Context)
        {
            this.Context = Context;
        }
        [HttpGet("Examen/{cursoId}/{alumnoId}")]
        public ActionResult<object> GetExamenByCursoAlumno(int cursoId, int alumnoId)
        {
            var matricula = Context.Matricula.Where(x => x.AlumnoId == alumnoId).FirstOrDefault();
            var gradoAcademicoCurso = matricula.GradoAcademico.GradoAcademicoCurso.Where(x => x.CursoId == cursoId && x.GradoAcademicoId == matricula.GradoAcademicoId).FirstOrDefault();
            var examenes = Context.Examen.Where(x => x.GradoAcademicoCursoId == gradoAcademicoCurso.GradoAcademicoCursoId);
            return new { Examen = examenes.ToList() };

        }

    }
}