using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace sisev_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarreraMateriasController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (Models.DBModels.TestVocacionalISCContext db = new Models.DBModels.TestVocacionalISCContext())
            {
                var lst = (from d in db.CarreraMaterias
                           select d).ToList();
                return Ok(lst);
            }
        }
        [HttpGet("{getCarreraMateria}")]
        public ActionResult GetById([FromBody] Models.Request.CarreraMateriasRequest model)
        {
            using (Models.DBModels.TestVocacionalISCContext db = new Models.DBModels.TestVocacionalISCContext())
            {
                var result = db.CarreraMaterias.FromSqlRaw("SELECT c.Nombre,SUM(Peso) as PesoTotal " +
                                                           "FROM CarreraMaterias cm " +
                                                           "JOIN Carreras c ON cm.IdCarrera = c.IdCarrera " +
                                                           "WHERE cm.IdCarrera = "+model.IdCarrera +
                                                           "GROUP BY cm.IdCarrera;").ToList();
                return Ok(result);
            }
        }
        
    }
}
