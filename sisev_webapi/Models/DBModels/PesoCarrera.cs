using System;
using System.Collections.Generic;

namespace sisev_webapi.Models.DBModels
{
    public partial class PesoCarrera
    {
        public int IdPeso { get; set; }
        public int? IdCarrera { get; set; }
        public int? Peso { get; set; }

        public virtual Carreras IdCarreraNavigation { get; set; }
    }
}
