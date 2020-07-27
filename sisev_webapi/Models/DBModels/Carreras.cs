using System;
using System.Collections.Generic;

namespace sisev_webapi.Models.DBModels
{
    public partial class Carreras
    {
        public Carreras()
        {
            CarreraMaterias = new HashSet<CarreraMaterias>();
            PesoCarrera = new HashSet<PesoCarrera>();
        }

        public int IdCarrera { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<CarreraMaterias> CarreraMaterias { get; set; }
        public virtual ICollection<PesoCarrera> PesoCarrera { get; set; }
    }
}
