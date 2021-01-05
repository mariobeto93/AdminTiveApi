using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AdminTiveDatos.AdminTiveEntities.Sesion;
using AdminTiveLogica.Sesiones;
namespace AdminTiveAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        
        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }

        //[Route("api/GenerarPedido")]
        [HttpPost("Autentificar")]
        public IActionResult Autentificar(Credenciales credenciales) 
        {
           
            return Ok(Usuarios.Autentificar(credenciales));
        }

        [HttpPost("RecuperarPermisos")]
        public IActionResult RecuperarPermisos(Usuario usuario)
        {

            return Ok(Usuarios.RecuperarPermisos(Convert.ToInt32(usuario.usuarioID)));
        }

        [HttpPost("RecuperarUsuario")]
        public IActionResult RecuperarUsuario(Usuario usuario)
        {
            return Ok(Usuarios.RecuperarUsuario(Convert.ToInt32(usuario.usuarioID)));
        }

        [HttpPost("isLoggedIn")]
        public IActionResult isLoggedIn(string email)
        {

            return Ok(Usuarios.isLoggedIn(email));
        }

        

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var rng = new Random();
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var rng = new Random();
            return "value";
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
