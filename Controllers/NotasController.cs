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
        private ScoolBdContext Context;
        public NotasController(ScoolBdContext Context)
        {
            this.Context = Context;
        }
        [HttpGet("Notas/{cursoId}/{alumnoId}")]
        public ActionResult<object> GetProfesorByCurso(int cursoId, int alumnoId)
        {
            try
            {
                
                var matricula = Context.Matricula.Where(x => x.AlumnoId == alumnoId).FirstOrDefault();
                var gradoAcademicoCurso = Context.GradoAcademicoCurso.Where(x => x.CursoId == cursoId && x.GradoAcademicoId == matricula.GradoAcademicoId).FirstOrDefault();
                var examenes = Context.Examen.Include(x => x.Nota).Where(x => x.GradoAcademicoCursoId == gradoAcademicoCurso.GradoAcademicoCursoId).FirstOrDefault();
                return  Ok( new { Notas = examenes.Nota.Select(x => new {AlumnoId= x.AlumnoId ,ExamenId=x.ExamenId,Nota =x.Nota1, NotaAlfabeto=x.NotaAlfabeto }).ToList() });
            }
            catch (Exception ex)
            {

                return NotFound(); ;
            }
            

        }


    }
}