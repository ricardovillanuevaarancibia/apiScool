using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class Permiso
    {
        public int PermisoId { get; set; }
        public int TipoPermisoId { get; set; }
        public int AlumnoId { get; set; }
        public string Observacion { get; set; }
        public int EstadoPermisoId { get; set; }
        public int EstadoId { get; set; }

        public virtual Alumno Alumno { get; set; }
        public virtual TipoGenerico TipoPermiso { get; set; }
    }
}
