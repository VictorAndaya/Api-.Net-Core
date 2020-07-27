using System;
using System.Collections.Generic;

namespace sisev_webapi.Models.DBModels
{
    public partial class CarreraMaterias
    {
        public int IdCarreraMateria { get; set; }
        public int? IdCarrera { get; set; }
        public int? IdMateria { get; set; }
        public int? Peso { get; set; }

        public virtual Carreras IdCarreraNavigation { get; set; }
        public virtual Materias IdMateriaNavigation { get; set; }
    }
}
