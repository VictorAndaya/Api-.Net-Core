using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using dapper_sisev.Models;
using Newtonsoft.Json;

namespace dapper_sisev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidacionController : ControllerBase
    {
        private string _connection = @"Server=localhost;Port=3306;User=root;Password=123456789;Database=TestVocacionalISC";

        [HttpGet]
        public IActionResult validation(Models.Usuarios model)
        {
            string jsonData = "";
            try
            {
                IEnumerable<Models.Usuarios> lst = null;
                using (var db = new MySqlConnection(_connection))
                {
                    var sql = "SELECT * FROM Usuarios WHERE Usuario = @Usuario AND Contrasena = @Contrasena;";
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
