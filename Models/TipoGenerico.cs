using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class TipoGenerico
    {
        public TipoGenerico()
        {
            Examen = new HashSet<Examen>();
            InverseTipoGenericoPadre = new HashSet<TipoGenerico>();
            Nota = new HashSet<Nota>();
            Notificacion = new HashSet<Notificacion>();
            Permiso = new HashSet<Permiso>();
        }

        public int TipoGenericoId { get; set; }
        public int? TipoGenericoPadreId { get; set; }
        public string Nombre { get; set; }
        public string Entidad { get; set; }
        public int EstadoId { get; set; }

        public virtual TipoGenerico TipoGenericoPadre { get; set; }
        public virtual ICollection<Examen> Examen { get; set; }
        public virtual ICollection<TipoGenerico> InverseTipoGenericoPadre { get; set; }
        public virtual ICollection<Nota> Nota { get; set; }
        public virtual ICollection<Notificacion> Notificacion { get; set; }
        public virtual ICollection<Permiso> Permiso { get; set; }
    }
}
