using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dapper_sisev.Models
{
    public class Preguntas
    {
        public int IdPregunta { get; set; }
        public int IdMateria { get; set; }
        public string Pregunta { get; set; }
    }
}
