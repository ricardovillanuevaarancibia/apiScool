using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiScool.ViewModel.Notas
{
    public class DTONota
    {
        public int NotaId { get; set; }
        public int ExamenId { get; set; }
        public int AlumnoId { get; set; }
        public decimal Nota { get; set; }
        public string NotaAlfabeto { get; set; }
        public int TipoNotaId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int EstadoId { get; set; }
    }
}
