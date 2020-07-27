using System;
using System.Collections.Generic;

namespace sisev_webapi.Models.DBModels
{
    public partial class Preguntas
    {
        public int IdPregunta { get; set; }
        public int? IdMateria { get; set; }
        public string Pregunta { get; set; }

        public virtual Materias IdMateriaNavigation { get; set; }
    }
}
