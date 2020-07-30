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
    public class MateriasController : ControllerBase
    {
        private readonly string _connection = @"Server=192.168.99.100;Port=3306;User=root;Password=123456789;Database=TestVocacionalISC";

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Models.Materias> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT * FROM Materias";
                lst = db.Query<Models.Materias>(sql);
            }
            return Ok(lst);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(Models.Materias model)
        {
            IEnumerable<Models.Materias> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT * FROM Materias WHERE IdMateria=@IdMateria";
                lst = db.Query<Models.Materias>(sql, model);
            }
            return Ok(lst);
        }

        [HttpPost]
        public IActionResult Set(Models.Materias model)
        {
            int result = 0;
            string response = "";
            try
            {
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "INSERT INTO Materias(Nombre) VALUES(@Nombre)";

                    result = db.Execute(sql, model);
                }
                if (result == 1)
                    response = "Se inserto correctamente la materia";
                else
                    response = "No se inserto la materia";
            }
            catch (Exception e)
            {
                response = e.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public IActionResult Edit(Models.Materias model)
        {
            int result = 0;
            string response = "";
            try
            {
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "UPDATE Materias SET Nombre=@Nombre WHERE IdMateria=@IdMateria;";

                    result = db.Execute(sql, model);
                }
                if (result == 1)
                    response = "Se actualizo correctamente la materia";
                else
                    response = "No se actualizo la materia";
            }
            catch (Exception e)
            {
                response = e.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(Models.Materias model)
        {
            int result = 0;
            string response = "";
            try
            {
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "DELETE FROM Materias WHERE IdMateria=@IdMateria;";

                    result = db.Execute(sql, model);
                }
                if (result == 1)
                    response = "Se elimino correctamente la materia";
                else
                    response = "No se elimino la materia";
            }
            catch (Exception e)
            {
                response = e.Message;
            }

            return Ok(response);
        }
    }
}
