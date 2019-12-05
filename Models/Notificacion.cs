using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class Notificacion
    {
        public Notificacion()
        {
            NotificacionRespuesta = new HashSet<NotificacionRespuesta>();
        }

        public int NotificacionId { get; set; }
        public string Comentario { get; set; }
        public int? TipoNotificacionId { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? UsuarioSendId { get; set; }
        public int? UsuarioRegistroId { get; set; }
        public int? EstadoId { get; set; }

        public virtual TipoGenerico TipoNotificacion { get; set; }
        public virtual Usuario UsuarioSend { get; set; }
        public virtual ICollection<NotificacionRespuesta> NotificacionRespuesta { get; set; }
    }
}
