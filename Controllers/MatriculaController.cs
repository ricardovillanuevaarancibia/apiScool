using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiScool.Models;
using ApiScool.ViewModel.Matricula;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiScool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private ColegioBdContext Context;
        public MatriculaController(ColegioBdContext Context)
        {
            this.Context = Context;
        }
        [HttpPost("Matricula/Create")]
        public ActionResult<object> AddCurso([FromBody]DTOMatricula matricula)
        {
 
            if (!ModelState.IsValid)
                return NotFound();
            var newMatricula = new Matricula()
            {
                MatriculaId = 0,
                CodigoMatricula =  matricula.CodigoMatricula,
                AlumnoId =matricula.AlumnoId,
                GradoAcademicoId =matricula.GradoAcademicoId,
                FechaCreacion = matricula.FechaCreacion,
                EstadoId = matricula.EstadoId
            };
            var cursoGrado = Context.GradoAcademicoCurso.Where(x => x.GradoAcademicoId == matricula.GradoAcademicoId).ToList();
         

            Context.Matricula.Add(newMatricula);

            Context.SaveChanges();
            return Ok();
        }

    }
}