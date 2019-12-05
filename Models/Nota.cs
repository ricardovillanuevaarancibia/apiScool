using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class Nota
    {
        public int NotaId { get; set; }
        public int? ExamenId { get; set; }
        public int AlumnoId { get; set; }
        public decimal Nota1 { get; set; }
        public string NotaAlfabeto { get; set; }
        public int TipoNotaId { get; set; }
        public int FechaRegistro { get; set; }
        public int EstadoId { get; set; }

        public virtual Alumno Alumno { get; set; }
        public virtual Examen Examen { get; set; }
        public virtual TipoGenerico TipoNota { get; set; }
    }
}
