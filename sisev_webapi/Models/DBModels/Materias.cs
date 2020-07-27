using System;
using System.Collections.Generic;

namespace sisev_webapi.Models.DBModels
{
    public partial class Materias
    {
        public Materias()
        {
            CarreraMaterias = new HashSet<CarreraMaterias>();
            Preguntas = new HashSet<Preguntas>();
        }

        public int IdMateria { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<CarreraMaterias> CarreraMaterias { get; set; }
        public virtual ICollection<Preguntas> Preguntas { get; set; }
    }
}
