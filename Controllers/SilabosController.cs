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
        private ScoolBdContext Context;
        public SilabosController(ScoolBdContext Context)
        {
            this.Context = Context;
        }


    }
}