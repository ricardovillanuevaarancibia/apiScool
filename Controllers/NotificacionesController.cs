using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiScool.Models;
using ApiScool.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiScool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionesController : ControllerBase
    {
        private ScoolBdContext Context;
        public NotificacionesController(ScoolBdContext Context)
        {
            this.Context = Context;
        }


        [HttpGet("Notificacion/{usuarioId}")]
        public ActionResult<object> GetNotificacionByAlumno(int usuarioId)
        {
        
            var notificacion = Context.Notificacion.Where(x => x.UsuarioSendId == usuarioId).ToList();
            return  Ok (new { Notificacion = notificacion });

        }

        [HttpPost("Notificacion/SendResponse")]
        public ActionResult<object> SendRequest([FromBody]ResponseNotificacion respuesta)
        {

            NotificacionRespuesta notificacionRespuesta = new NotificacionRespuesta()
            {
                NotificacionId = respuesta.NotificacionId,
                Mensaje = respuesta.Mensaje,
                EstadoId = 1
            };
            Context.NotificacionRespuesta.Add(notificacionRespuesta);
            Context.SaveChanges();
            return  Ok ();

        }
    }
}