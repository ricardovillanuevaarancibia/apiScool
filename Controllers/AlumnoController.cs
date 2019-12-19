using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiScool.Helpers;
using ApiScool.Models;
using ApiScool.ViewModel.Alumnos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiScool.Controllers
{
    [Route("api/[controller]")]
 
    [ApiController]  
    public class AlumnoController : ControllerBase
    {
        private ColegioBdContext Context;
        public AlumnoController(ColegioBdContext Context)
        {
            this.Context = Context;
        }
        [HttpGet("Alumnos")]
        public ActionResult<object> GetAlumno() {
        
            return new { alumnos = Context.Alumno.ToList() };
        }
        [HttpGet("Alumnos/{id}")]
        public ActionResult<object>GetAlumnoByParent(int id){
            return new { alumnos = Context.UsuarioAlumno.Where(x => x.UsuarioId==id).Select(x => x.Usuario).ToList() };
        }
        [HttpPost("Alumnos/Create")]
        public ActionResult<object> AddAlumno([FromBody]DTOAlumno alumno )
        {
            if (!ModelState.IsValid)
                return NotFound();
            var newAlumno = new Alumno()
            {
                Nombre =alumno.Nombre,
                ApellidoPaterno=alumno.ApellidoPaterno,
                ApellidoMaterno =alumno.ApellidoMaterno,
                Dni=alumno.Dni,
                FechaNacimiento = alumno.FechaNacimiento,
                EstadoId = alumno.EstadoId
            };
            Context.Alumno.Add(newAlumno);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut("Alumnos/Update/{id}")]
        public ActionResult<object> UpdateAlumno([FromBody]DTOAlumno alumno)
        {
            if (!ModelState.IsValid)
                return NotFound();

            var UpdateAlumno = Context.Alumno.Find(alumno.AlumnoId);
            UpdateAlumno.Nombre=alumno.Nombre;
            UpdateAlumno.ApellidoPaterno = alumno.ApellidoPaterno;
            UpdateAlumno.Dni = alumno.Dni;
            UpdateAlumno.FechaNacimiento = alumno.FechaNacimiento;
            Context.SaveChanges();
            return Ok();
        }


    }
}
