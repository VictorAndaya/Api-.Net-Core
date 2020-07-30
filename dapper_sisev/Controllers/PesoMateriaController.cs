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
    public class PesoMateriaController : ControllerBase
    {
        private string _connection = @"Server=192.168.99.100;Port=3306;User=root;Password=123456789;Database=TestVocacionalISC";

        [HttpGet("getPesoMateria")]
        public IActionResult GetById(Models.PesoMateria model)
        {
            IEnumerable<Models.PesoMateria> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = ""; //Falta
                lst = db.Query<Models.PesoMateria>(sql, model);
            }
            return Ok(lst);
        }

        [HttpDelete("deletePesoMateria")]
        public IActionResult Delete(Models.PesoMateria model)
        {
            int result = 0;
            string response = "";
            try
            {
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "DELETE FROM CarreraMaterias WHERE IdCarreraMateria=@IdCarreraMateria;";

                    result = db.Execute(sql, model);
                }
                if (result == 1)
                    response = "La pregunta se elimino correctamente";
                else
                    response = "No se pudo eliminar";
            }
            catch (Exception e)
            {
                response = e.Message;
            }

            return Ok(response);
        }

        [HttpPut("updatePesoMateria")]
        public IActionResult Edit(Models.PesoMateria model)
        {
            int result = 0;
            string response = "";
            try
            {
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "UPDATE PesoMateria SET IdCarrera=@IdCarrera, IdMateria=@IdMateria, Peso=@Peso WHERE IdCarreraMateria=@IdCarreraMateria;";

                    result = db.Execute(sql, model);
                }
                if (result == 1)
                    response = "El peso se actualizo correctamente";
                else
                    response = "No se actualizo el peso";
            }
            catch (Exception e)
            {
                response = e.Message;
            }

            return Ok(response);
        }

        [HttpPost("setPesoMateria")]
        public IActionResult Set(Models.PesoMateria model)
        {
            int result = 0;
            string response = "";
            try
            {
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "INSERT INTO CarreraMaterias (IdCarrera, IdMateria, Peso) VALUES(@IdCarrera, @IdMateria, @Peso)";

                    result = db.Execute(sql, model);
                }
                if (result == 1)
                    response = "El peso se agregó correctamente";
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
