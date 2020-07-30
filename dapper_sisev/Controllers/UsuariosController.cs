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
    public class UsuariosController : ControllerBase
    {
        private string _connection = @"Server=192.168.99.100;Port=3306;User=root;Password=123456789;Database=TestVocacionalISC";

        [HttpPost("setUsuario")]
        public IActionResult SetUsuario(Models.Usuarios model)
        {
            int result = 0;
            string response = "";
            try
            {
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "INSERT INTO Usuarios(Rol, Nombre, Usuario, Contrasena) VALUES(0,@Nombre,@Usuario,@Contrasena);";

                    result = db.Execute(sql, model);
                }
                if (result == 1)
                    response = "Se inserto correctamente el usuario";
                else
                    response = "No se inserto el usuario";
            }
            catch (Exception e)
            {
                response = e.Message;
            }

            return Ok(response);
        }
        [HttpGet("getUsuario")]
        public IActionResult GetUsuario(Models.Usuarios model)
        {
            string response = "";
            try
            {
                IEnumerable<Models.Usuarios> lst = null;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "SELECT * FROM Usuarios WHERE Usuario = @Usuario;";
                    lst = db.Query<Models.Usuarios>(sql, model);
                }
                if (lst.Count() == 1)
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
