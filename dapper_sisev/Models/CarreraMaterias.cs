using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dapper_sisev.Models
{
    public class CarreraMaterias
    {
        public int IdCarreraMateria { get; set; }
        public int IdCarrera { get; set; }
        public int IdMateria { get; set; }
        public int Peso { get; set; }
    }
    public class CarreraMateriasTotal
    {
        public string Nombre { get; set; }
        public int PesoTotal { get; set; }
    }
}
