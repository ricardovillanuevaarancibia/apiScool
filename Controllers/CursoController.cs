using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApiScool.Models;
using ApiScool.ViewModel.Cursos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiScool.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private ColegioBdContext Context;
        public CursoController(ColegioBdContext Context)
        {
            this.Context = Context;
        }

        public ActionResult<object> GetCurso()
        {

            return new { Cursos = Context.Curso.ToList() };
        }
        [HttpGet("Alumno/{id}")]
        public ActionResult<object> GetCursoByAlumno(int id)
        {
            var matricula = Context.Matricula.Where(x => x.AlumnoId == id && x.EstadoId==1).FirstOrDefault();

            return new { Curso = Context.GradoAcademicoCurso.Where(x => x.GradoAcademicoId == matricula.GradoAcademicoId && x.EstadoId==1 && x.CursoId==1 ).Select(x => x.Curso).ToList() };
        }
        [HttpGet("Profesor/{cursoId}/{alumnoId}")]
        public ActionResult<object> GetProfesorByCurso(int cursoId,int alumnoId)
        {
            DTOCurso model = new DTOCurso();
            var matricula = Context.Matricula.Where(x => x.AlumnoId == alumnoId && x.EstadoId==1).FirstOrDefault();
 

            return  Context.MatriculaCursoProfesor.Include("Profesor").Where(x => x.CursoId == cursoId && x.Matricula.MatriculaId== matricula.MatriculaId &&x.ProfesorId ==1 && x.EstadoId==1).Select(x => new
            {
                 x.Profesor,
            }).FirstOrDefault() ;

        }
     
        [HttpGet("Silabos/{cursoId}/{alumnoId}")]
        public ActionResult<object> GetSilabosByCurso(int cursoId, int alumnoId)
        {
            var matricula = Context.Matricula.Where(x => x.AlumnoId == alumnoId && x.EstadoId==1).FirstOrDefault();
          
            return new { Silabo = Context.Silabo.Where(x => x.CursoGradoAcademicoId == 1).FirstOrDefault()};

        }
        [HttpPost("Cursos/Create")]
        public ActionResult<object> AddCurso([FromBody]DTOCurso curso)
        {
            if (!ModelState.IsValid)
                return NotFound();
            var newCurso = new Curso()
            {
                Nombre = curso.Nombre,
                Image =curso.Image,
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