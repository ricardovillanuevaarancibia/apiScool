using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class Actividades
    {
        public int ActividadesId { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Descripcion { get; set; }
        public int? EstadoId { get; set; }
    }
}
