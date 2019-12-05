using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiScool.Models;
using ApiScool.ViewModel.Cursos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiScool.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private ScoolBdContext Context;
        public CursoController(ScoolBdContext Context)
        {
            this.Context = Context;
        }
        [HttpGet("Curso")]
        public ActionResult<object> GetCurso()
        {

            return new { Cursos = Context.Curso.ToList() };
        }
        [HttpGet("Cursos/Alumno/{id}")]
        public ActionResult<object> GetCursoByAlumno(int id)
        {
            var matricula = Context.Matricula.Where(x => x.AlumnoId == id).FirstOrDefault();

            return new { Curso = Context.GradoAcademicoCurso.Where(x => x.GradoAcademicoId == matricula.GradoAcademicoId).Select(x => x.Curso).ToList() };
        }
        [HttpGet("Cursos/Profesor/{cursoId}/{alumnoId}")]
        public ActionResult<object> GetProfesorByCurso(int cursoId,int alumnoId)
        {
            var matricula = Context.Matricula.Where(x => x.AlumnoId == alumnoId).FirstOrDefault();
            var matriculaCurso = Context.GradoAcademicoCurso.Where(x => x.GradoAcademicoId == matricula.GradoAcademicoId && x.CursoId == cursoId).FirstOrDefault();
            return new { Profesor = matriculaCurso.MatriculaCursoProfesor.FirstOrDefault().Profesor};


        }
        [HttpGet("Cursos/Silabos/{cursoId}/{alumnoId}")]
        public ActionResult<object> GetSilabosByCurso(int cursoId, int alumnoId)
        {
            var matricula = Context.Matricula.Where(x => x.AlumnoId == alumnoId).FirstOrDefault();
            var gradoAcademicoCurso = Context.GradoAcademicoCurso.Where(x => x.CursoId == cursoId && x.GradoAcademicoId == matricula.GradoAcademicoId).FirstOrDefault();
          
            return new { Silabo = Context.Silabo.Where(x => x.CursoGradoAcademicoId == gradoAcademicoCurso.GradoAcademicoCursoId).FirstOrDefault()};

        }
        [HttpPost("Cursos/Create")]
        public ActionResult<object> AddCurso([FromBody]DTOCurso curso)
        {
            if (!ModelState.IsValid)
                return NotFound();
            var newCurso = new Curso()
            {
                Nombre = curso.Nombre,
                EstadoId=1
            
            };
            Context.Curso.Add(newCurso);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut("Cursos/Update/{id}")]
        public ActionResult<object> UpdateCurso([FromBody]DTOCurso curso)
        {
            if (!ModelState.IsValid)
                return NotFound();

            var updateCurso = Context.Curso.Find(curso.CursoId);
            updateCurso.Nombre = curso.Nombre;
  
            Context.SaveChanges();
            return Ok();
        }


    }
}