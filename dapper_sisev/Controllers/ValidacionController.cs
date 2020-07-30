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
    public class ValidacionController : ControllerBase
    {
        private string _connection = @"Server=192.168.99.100;Port=3306;User=root;Password=123456789;Database=TestVocacionalISC";

        [HttpGet]
        public IActionResult validation(Models.Usuarios model)
        {
            string response = "";
            try
            {
                IEnumerable<Models.Usuarios> lst = null;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "SELECT * FROM Usuarios WHERE Usuario = @Usuario AND Contrasena = @Contrasena;";
                    lst = db.Query<Models.Usuarios>(sql, model);
                }
                if (lst.Count()==1)
                    response = "Se encontro el usuario";
                else
                    response = "No se encontro";
            }
            catch (Exception e)
            {
                response = e.Message;
            }

            return Ok(response);
        }
    }
}
