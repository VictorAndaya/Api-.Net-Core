using System;
using System.Collections.Generic;

namespace sisev_webapi.Models.DBModels
{
    public partial class UsuariosResultado
    {
        public bool? Rol { get; set; }
        public int? IdUsuario { get; set; }
        public string Resultado1 { get; set; }
        public string Resultado2 { get; set; }
        public string Resultado3 { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
