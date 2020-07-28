using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sisev_webapi.Models.Request
{
    public class CarreraMateriasRequest
    {
        public int IdCarreraMateria { get; set; }
        public int IdCarrera { get; set; }
        public int IdMateria { get; set; }
        public int Peso { get; set; }


    }
}
