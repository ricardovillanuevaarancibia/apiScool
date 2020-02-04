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
    public class ActividadesController : ControllerBase
    {
        private ColegioBdContext Context;
        public ActividadesController(ColegioBdContext Context)
        {
            this.Context = Context;
        }
        [HttpGet("LstActividades")]
        public ActionResult<object> GetActividades()
        {

            return new { actividades = Context.Actividades.Where(x => x.EstadoId==1).Select(x=> new {x.Nombre,x.ActividadesId,x.Descripcion,x.EstadoId,FechaFin= x.FechaFin.Value.ToString("dd-MM-yyyy"), FechaInicio=x.FechaInicio.Value.ToString("dd-MM-yyyy"),imagen =x.Imagen}).ToList() };
        }
    }
}