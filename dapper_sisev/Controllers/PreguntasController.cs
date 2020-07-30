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
    public class PreguntasController : ControllerBase
    {
        private string _connection = @"Server=192.168.99.100;Port=3306;User=root;Password=123456789;Database=TestVocacionalISC";

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Models.Preguntas> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT * FROM Preguntas";
                lst = db.Query<Models.Preguntas>(sql);
            }
            return Ok(lst);
        }
        [HttpPost("setPregunta")]
        public IActionResult SetPregunta(Models.Preguntas model)
        {
            int result = 0;
            string response = "";
            try
            {
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "INSERT INTO Preguntas(IdMateria,Pregunta) VALUES(@idMateria,@pregunta);";
                    result = db.Execute(sql, model);
                }
                if (result == 1)
                    response = "Se inserto correctamente la pregunta";
                else
                    response = "No se inserto la pregunta";
            }
            catch (Exception e)
            {
                response = e.Message;
            }
            return Ok(response);
        }
        [HttpPut("updatePregunta")]
        public IActionResult UpdatePregunta(Models.Preguntas model)
        {
            int result = 0;
            string response = "";
            try
            {
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "UPDATE Preguntas SET IdMateria=@IdMateria,Pregunta=@Pregunta WHERE IdPregunta=@IdPregunta;";
                    result = db.Execute(sql, model);
                }
                if (result == 1)
                    response = "Se actualizo correctamente la pregunta";
                else
                    response = "No se actualizo la pregunta";
            }
            catch (Exception e)
            {
                response = e.Message;
            }
            return Ok(response);
        }
        [HttpDelete("deletePregunta")]
        public IActionResult DeletePregunta(Models.Preguntas model)
        {
            int result = 0;
            string response = "";
            try
            {
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "DELETE FROM Preguntas WHERE IdPregunta=@IdPregunta;";
                    result = db.Execute(sql, model);
                }
                if (result == 1)
                    response = "Se elimino correctamente la pregunta";
                else
                    response = "No se elimino la pregunta";
            }
            catch (Exception e)
            {
                response = e.Message;
            }
            return Ok(response);
        }
    }
}
