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
        private ColegioBdContext Context;
        public HorarioController(ColegioBdContext Context)
        {
            this.Context = Context;
        }
 

        [HttpGet("Horario/{alumnoId}")]
        public ActionResult<object> GetExamenByCursoAlumno( int alumnoId)
        {
            var matricula = Context.Matricula.Where(x => x.AlumnoId == alumnoId).FirstOrDefault();
            var horario = Context.Horario.Where(x => x.GradoAcademicoId == matricula.GradoAcademicoId &&x.EstadoId==1);
            return new { Horario = horario.ToList() };

        }
    }
}