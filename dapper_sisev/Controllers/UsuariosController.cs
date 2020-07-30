using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using dapper_sisev.Models;
using System.Security.Cryptography.Xml;
using Newtonsoft.Json;

namespace dapper_sisev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private string _connection = @"Server=localhost;Port=3306;User=root;Password=123456789;Database=TestVocacionalISC";

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
        [HttpGet("getRolUsuario")]
        public IActionResult GetRolUsuario(Models.Usuarios model)
        {
            string jsonData = "";
            try
            {
                IEnumerable<Models.Usuarios> lst = null;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "SELECT * FROM Usuarios WHERE Usuario = @Usuario;";
                    lst = db.Query<Models.Usuarios>(sql, model);
                }
                if (lst.Count() == 1)
                {
                    var first = lst.First();
                    var obj = new Usuarios { Id = first.Id, Rol = first.Rol, Nombre = first.Nombre, Usuario = first.Usuario, Contrasena = first.Contrasena };
                    jsonData = JsonConvert.SerializeObject(obj);
                }
                return Ok(jsonData);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}
