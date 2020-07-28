using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace sisev_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrerasController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (Models.DBModels.TestVocacionalISCContext db = new Models.DBModels.TestVocacionalISCContext())
            {
                var lst = (from d in db.Carreras
                           select d).ToList();
                return Ok(lst);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Models.Request.CarrerasRequest model)
        {
            using (Models.DBModels.TestVocacionalISCContext db = new Models.DBModels.TestVocacionalISCContext())
            {
                Models.DBModels.Carreras oCarreras = new Models.DBModels.Carreras();
                oCarreras.Nombre = model.Nombre;
                db.Carreras.Add(oCarreras);
                db.SaveChanges();
            }
            return Ok();
        }
        [HttpPut]
        public ActionResult Put([FromBody] Models.Request.CarrerasRequest model)
        {
            using (Models.DBModels.TestVocacionalISCContext db = new Models.DBModels.TestVocacionalISCContext())
            {
                Models.DBModels.Carreras oCarreras = db.Carreras.Find(model.IdCarrera);
                oCarreras.Nombre = model.Nombre;
                db.Entry(oCarreras).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            return Ok();
        }
        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Request.CarrerasRequest model)
        {
            using (Models.DBModels.TestVocacionalISCContext db = new Models.DBModels.TestVocacionalISCContext())
            {
                Models.DBModels.Carreras oCarreras = db.Carreras.Find(model.IdCarrera);
                db.Carreras.Remove(oCarreras);
                db.SaveChanges();
            }
            return Ok();
        }

    }
}
