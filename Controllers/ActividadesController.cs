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
        public ActionResult<object> GetAlumno()
        {

            return new { actividades = Context.Actividades.ToList() };
        }
    }
}