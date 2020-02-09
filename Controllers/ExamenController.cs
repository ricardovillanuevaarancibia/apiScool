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
    public class ExamenController : ControllerBase
    {
        private ColegioBdContext Context;
        public ExamenController(ColegioBdContext Context)
        {
            this.Context = Context;
        }
        [HttpGet("Examen/{cursoId}/{alumnoId}")]
        public ActionResult<object> GetExamenByCursoAlumno(int cursoId, int alumnoId)
        {
            var matricula = Context.Matricula.Where(x => x.AlumnoId == alumnoId).FirstOrDefault();
            var gradoAcademicoCurso = Context.GradoAcademicoCurso.Where(x => x.CursoId == cursoId && x.GradoAcademicoId == matricula.GradoAcademicoId).FirstOrDefault();
            var examenes = Context.Examen.Where(x => x.GradoAcademicoCursoId == gradoAcademicoCurso.GradoAcademicoCursoId && x.EstadoId==1);
            examenes.ToList();
            return new { Examen = examenes.Select(x => new {EstadoId =x.EstadoId,FechaExamen =x.FechaExamen.Value.ToString("dd-MM-yyyy"),TipoExamen =x.TipoExamen.Nombre }) };

        }

    }
}