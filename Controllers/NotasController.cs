using System;
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
    public class NotasController : ControllerBase
    {
        private ScoolBdContext Context;
        public NotasController(ScoolBdContext Context)
        {
            this.Context = Context;
        }
        [HttpGet("Notas/{cursoId}/{alumnoId}")]
        public ActionResult<object> GetProfesorByCurso(int cursoId, int alumnoId)
        {
            var matricula = Context.Matricula.Where(x => x.AlumnoId == alumnoId).FirstOrDefault();
            var gradoAcademicoCurso = matricula.GradoAcademico.GradoAcademicoCurso.Where(x => x.CursoId == x.CursoId && x.GradoAcademicoId == matricula.GradoAcademicoId).FirstOrDefault();
            var examenes = Context.Examen.Where(x => x.GradoAcademicoCursoId == gradoAcademicoCurso.GradoAcademicoCursoId).FirstOrDefault();
            return new { Notas = examenes.Nota.ToList()};

        }


    }
}