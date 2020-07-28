using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sisev_webapi.Models.DBModels;

namespace sisev_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private TestVocacionalISCContext _context;

        public WeatherForecastController(TestVocacionalISCContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var carreras = _context.Carreras.ToList();
            return Ok(carreras);
        }
    }
}
