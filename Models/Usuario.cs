using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Notificacion = new HashSet<Notificacion>();
            UsuarioAlumno = new HashSet<UsuarioAlumno>();
        }

        public int UsuarioId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string ApellidosM { get; set; }
        public string ApellidosP { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int? EstadoId { get; set; }

        public virtual ICollection<Notificacion> Notificacion { get; set; }
        public virtual ICollection<UsuarioAlumno> UsuarioAlumno { get; set; }
    }
}
