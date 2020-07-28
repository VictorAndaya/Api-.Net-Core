using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sisev_webapi.Models.Request
{
    public class CarrerasRequest
    {
        public int IdCarrera { get; set; }
        public string Nombre { get; set; }
    }
    /*
    public class CarrerasEditRequest
    {
        public int IdCarrera { get; set; }
        public string Nombre { get; set; }
    }*/
}
