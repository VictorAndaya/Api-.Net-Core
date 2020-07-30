using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using dapper_sisev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace dapper_sisev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesoCarreraController : ControllerBase
    {
        private string _connection = @"Server=192.168.99.100;Port=3306;User=root;Password=123456789;Database=TestVocacionalISC";

        [HttpGet]
        public IActionResult GetById(Models.PesoCarrera model)
        {
            IEnumerable<Models.CarreraMaterias> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT * FROM PesoCarrera;";
                lst = db.Query<Models.CarreraMaterias>(sql, model);
            }
            return Ok(lst);
        }

        [HttpDelete]
        public IActionResult Delete(Models.PesoCarrera model)
        {
            int result = 0;
            string response = "";
            try
            {
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "DELETE FROM PesoCarrera WHERE IdPeso=@IdPeso;";

                    result = db.Execute(sql, model);
                }
                if (result == 1)
                    response = "Se elimino correctamente el peso de la carrera";
                else
                    response = "No se pudo eliminar el peso";
            }
            catch (Exception e)
            {
                response = e.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public IActionResult Edit(Models.PesoCarrera model)
        {
            int result = 0;
            string response = "";
            try
            {
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "UPDATE PesoCarrera SET IdCarrera=@IdCarrera, Peso=@Peso WHERE IdPeso=@IdPeso;";

                    result = db.Execute(sql, model);
                }
                if (result == 1)
                    response = "Se actualizo correctamente el peso de la carrera";
                else
                    response = "No se actualizo el peso";
            }
            catch (Exception e)
            {
                response = e.Message;
            }

            return Ok(response);
        }

        [HttpPost()]
        public IActionResult Set(Models.PesoCarrera model)
        {
            int result = 0;
            string response = "";
            try
            {
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "INSERT INTO PesoCarrera (IdCarrera, Peso) VALUES(@IdCarrera, @Peso)";

                    result = db.Execute(sql, model);
                }
                if (result == 1)
                    response = "El peso de la carrera se ha insertado correctamente";
                else
                    response = "No se inserto el peso";
            }
            catch (Exception e)
            {
                response = e.Message;
            }

            return Ok(response);
        }
    }
}
