using System;
using System.Collections.Generic;

namespace ApiScool.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? ProfesorId { get; set; }
        public string Rol { get; set; }
        public int? EstadoId { get; set; }
    }
}
