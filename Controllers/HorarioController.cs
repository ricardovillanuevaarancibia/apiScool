using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiScool.Models;
using ApiScool.ViewModel.Cursos;
using ApiScool.ViewModel.Horario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiScool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        private ScoolBdContext Context;
        public HorarioController(ScoolBdContext Context)
        {
            this.Context = Context;
        }
        [HttpPost("Horario/Create")]
        public ActionResult<object> AddHorario([FromBody]DTOHorario horario)
        {
            if (!ModelState.IsValid)
                return NotFound();
            var newHorario = new Horario()
            {
                GradoAcademicoId = horario.GradoAcademicoId,
                CursoId = horario.CursoId,
                HoraInicio = horario.HorarioInicio,
                HoraFin = horario.HoraFin,
                Lunes = horario.Lunes ?? false,
                Martes = horario.Martes ?? false,
                Miercoles = horario.Miercoles ?? false,
                Jueves=horario.Jueves??false,
                Viernes=horario.Viernes??false,
                Sabado=horario.Sabado??false,
                Domingo=horario.Domingo??false,
                EstadoId=1
            };

            Context.Horario.Add(newHorario);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut("Horario/Update/{id}")]
        public ActionResult<object> UpdateHorario([FromBody]DTOHorario horario)
        {
            if (!ModelState.IsValid)
                return NotFound();
            var updateHorario = Context.Horario.Find(horario.HorarioId);
            updateHorario.GradoAcademicoId = horario.GradoAcademicoId;
            updateHorario.CursoId = horario.CursoId;
            updateHorario.HoraInicio = horario.HorarioInicio;
            updateHorario.HoraFin = horario.HoraFin;
            updateHorario.Lunes = horario.Lunes ?? false;
            updateHorario.Martes = horario.Martes ?? false;
            updateHorario.Miercoles = horario.Miercoles ?? false;
            updateHorario.Jueves = horario.Jueves ?? false;
            updateHorario.Viernes = horario.Viernes ?? false;
            updateHorario.Sabado = horario.Sabado ?? false;
            updateHorario.Domingo = horario.Domingo ?? false;
            updateHorario.EstadoId = 1;
            Context.SaveChanges();
            return Ok();
        }

        [HttpGet("Horario/{alumnoId}")]
        public ActionResult<object> GetExamenByCursoAlumno( int alumnoId)
        {
            var matricula = Context.Matricula.Where(x => x.AlumnoId == alumnoId).FirstOrDefault();
            var horario = Context.Horario.Where(x => x.GradoAcademicoId == matricula.GradoAcademicoId);
            return new { Horario = horario.ToList() };

        }
    }
}