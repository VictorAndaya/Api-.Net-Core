using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dapper_sisev.Models
{
    //public class Usuarios
    //{
    //    public string Usuario { get; set; }
    //    public string Contrasena { get; set; }
    //}
    public class Usuarios
    {
        public int Id { get; set; }
        public bool Rol { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
    }
}
