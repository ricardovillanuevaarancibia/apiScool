using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiScool.Models;
using ApiScool.ViewModel.Profesor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiScool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private ColegioBdContext Context;
        public ProfesorController(ColegioBdContext Context)
        {
            this.Context = Context;
        }

        [HttpGet("Profesor")]
        public ActionResult<object> GetProfesor()
        {

            return new { Profesor = Context.Profesor.ToList() };
        }
        [HttpPost("Profesor/Create")]
        public ActionResult<object> AddProfesor([FromBody]DTOProfesor profesor)
        {
            if (!ModelState.IsValid)
                return NotFound();
            var newProfesor = new Profesor()
            {
                Nombre = profesor.Nombre,
                ApellidoPaterno = profesor.ApellidoPaterno,
                ApellidoMaterno = profesor.ApellidoMaterno,
                Dni = profesor.Dni,
                EstadoId = profesor.EstadoId
            };
            Context.Profesor.Add(newProfesor);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut("profesor/Update/{id}")]
        public ActionResult<object> UpdateProfesor([FromBody]DTOProfesor profesor)
        {
            if (!ModelState.IsValid)
                return NotFound();

            var UpdateProfesor = Context.Profesor.Find(profesor.ProfesorId);
            UpdateProfesor.Nombre = profesor.Nombre;
            UpdateProfesor.ApellidoPaterno = profesor.ApellidoPaterno;
            UpdateProfesor.Dni = profesor.Dni;
            Context.SaveChanges();
            return Ok();
        }
        [HttpGet("Profesor/ListaCursos/{profesorId}")]
        public ActionResult<object> GetCursoByProfesor(int profesorId)
        {
            return new
            { Cursos =
                Context.MatriculaCursoProfesor.Where(x => x.ProfesorId == profesorId && x.EstadoId==1).Select(x => new
                {
                    x.Curso,
                    x.Matricula.GradoAcademico.Nombre
                }).ToList()
            };
        }
    }
}