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
    public class CarreraMateriasController : ControllerBase
    {
        private string _connection = @"Server=localhost;Port=3306;User=root;Password=123456789;Database=TestVocacionalISC";

        [HttpGet("getCarreraMateria")]
        public IActionResult GetById(Models.CarreraMaterias model)
        {
            IEnumerable<Models.CarreraMaterias> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT * FROM CarreraMaterias WHERE IdCarrera=@IdCarrera AND IdMateria=@IdMateria;";
                lst = db.Query<Models.CarreraMaterias>(sql, model);
            }
            return Ok(lst);
        }

        [HttpGet("getMotor")]
        public IActionResult GetMotor(Models.CarreraMaterias model)
        {
            IEnumerable<Models.CarreraMaterias> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT Peso FROM CarreraMaterias WHERE IdMateria=@IdMateria;";
                lst = db.Query<Models.CarreraMaterias> (sql, model);
            }
            return Ok(lst);
        }

        [HttpGet("getFinal")]
        public IActionResult GetFinal(Models.CarreraMaterias model)
        {
            IEnumerable<Models.CarreraMaterias> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT IdMateria,Peso FROM CarreraMaterias WHERE IdMateria=@IdMateria AND IdCarrera=@IdCarrera;";
                lst = db.Query<Models.CarreraMaterias>(sql, model);
            }
            return Ok(lst);
        }
        [HttpGet]
        public IActionResult GetDis()
        {
            IEnumerable<Models.CarreraMaterias> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT DISTINCT IdCarrera FROM CarreraMaterias;";
                lst = db.Query<Models.CarreraMaterias>(sql);
            }
            return Ok(lst);
        }

        [HttpGet("getTotal")]
        public IActionResult GetTotal(Models.CarreraMaterias model)
        {
            IEnumerable<Models.CarreraMateriasTotal> lst = null;
            using (var db = new MySqlConnection(_connection))
            {
                var sql = "SELECT c.Nombre,SUM(Peso) as PesoTotal FROM CarreraMaterias cm JOIN Carreras c ON cm.IdCarrera = c.IdCarrera WHERE cm.IdCarrera = @IdCarrera;";
                lst = db.Query<Models.CarreraMateriasTotal>(sql, model);
            }
            return Ok(lst);
        }

        [HttpPost("setCarreraMaterias")]
        public IActionResult Set(Models.CarreraMaterias model)
        {
            int result = 0;
            string response = "";
            try
            {
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "INSERT INTO CarreraMaterias (IdCarrera, IdMateria, Peso) VALUES(@IdCarrera,@IdMateria,@Peso)";

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
    }
}
