using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiScool.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiScool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        private ColegioBdContext Context;
        public NotasController(ColegioBdContext Context)
        {
            this.Context = Context;
        }
        [HttpGet("Notas/{cursoId}/{alumnoId}")]
        public ActionResult<object> GetProfesorByCurso(int cursoId, int alumnoId)
        {
            try {
                var gradoAcademico = Context.Matricula.Where(x => x.AlumnoId == alumnoId).FirstOrDefault();
                var gradoAcademicoCurso = Context.GradoAcademicoCurso.Where(x => x.CursoId == cursoId && x.GradoAcademicoId== gradoAcademico.GradoAcademicoId).FirstOrDefault();
                var Nota = Context.Nota.Include(x => x.Examen).Include(x => x.Examen.GradoAcademicoCurso.Curso).Include(x => x.Examen.TipoExamen).Where(x => x.Examen.GradoAcademicoCursoId == gradoAcademicoCurso.GradoAcademicoCursoId && x.AlumnoId == alumnoId && x.EstadoId==1).ToList();

                return  Ok( new { Notas = Nota.Select(x => new {AlumnoId= x.AlumnoId,Curso = x.Examen.GradoAcademicoCurso.Curso.Nombre ,FechaExamen=x.Examen.FechaExamen.Value.ToShortDateString(),ExamenId=x.ExamenId,TipoExamen =x.Examen.TipoExamen.Nombre,Nota =x.Nota1, NotaAlfabeto=x.NotaAlfabeto }).ToList() });
            }
            catch (Exception ex)
            {
                return NotFound(); ;
            }
            

        }


    }
}