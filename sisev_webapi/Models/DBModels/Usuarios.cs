using System;
using System.Collections.Generic;

namespace sisev_webapi.Models.DBModels
{
    public partial class Usuarios
    {
        public int Id { get; set; }
        public bool? Rol { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
    }
}
