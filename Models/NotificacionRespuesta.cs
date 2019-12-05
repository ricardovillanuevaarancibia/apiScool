using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class NotificacionRespuesta
    {
        public int NotificacionRespuestaId { get; set; }
        public int? NotificacionId { get; set; }
        public string Mensaje { get; set; }
        public int? EstadoId { get; set; }

        public virtual Notificacion Notificacion { get; set; }
    }
}
