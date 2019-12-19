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
    public class SilabosController : ControllerBase
    {
        private ColegioBdContext Context;
        public SilabosController(ColegioBdContext Context)
        {
            this.Context = Context;
        }


    }
}