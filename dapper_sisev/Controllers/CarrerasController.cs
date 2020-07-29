using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace dapper_sisev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrerasController : ControllerBase
    {
        private string _connection = @"Server=localhost;Port=3306;User=root;Password=123456789;Database=TestVocacionalISC";

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Models.Carreras> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT * FROM Carreras";
                lst = db.Query<Models.Carreras>(sql);
            }
            return Ok(lst);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(Models.Carreras model)
        {
            IEnumerable<Models.Carreras> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT * FROM Carreras WHERE IdCarrera=@IdCarrera";
                lst = db.Query<Models.Carreras>(sql,model);
            }
            return Ok(lst);
        }

        [HttpPost]
        public IActionResult Set(Models.Carreras model)
        {
            int result = 0;
            string response = "";
            try
            {
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "INSERT INTO Carreras(Nombre) VALUES(@Nombre)";

                    result = db.Execute(sql, model);
                }
                if (result == 1)
                    response = "Se inserto correctamente la carrera";
                else
                    response = "No se inserto la carrera";
            }
            catch (Exception e)
            {
                response = e.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public IActionResult Edit(Models.Carreras model)
        {
            int result = 0;
            string response = "";
            try
            {
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "UPDATE Carreras SET Nombre=@Nombre WHERE IdCarrera=@IdCarrera;";

                    result = db.Execute(sql, model);
                }
                if (result == 1)
                    response = "Se actualizo correctamente la carrera";
                else
                    response = "No se actualizo la carrera";
            }
            catch (Exception e)
            {
                response = e.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(Models.Carreras model)
        {
            int result = 0;
            string response = "";
            try
            {
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "DELETE FROM Carreras WHERE IdCarrera=@IdCarrera;";

                    result = db.Execute(sql, model);
                }
                if (result == 1)
                    response = "Se elimino correctamente la carrera";
                else
                    response = "No se elimino la carrera";
            }
            catch(Exception e)
            {
                response = e.Message;
            }

            return Ok(response);
        }
    }
}
