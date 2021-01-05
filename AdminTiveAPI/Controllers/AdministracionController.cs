using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminTiveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministracionController : ControllerBase
    {
        [HttpPost("RecuperarPermisos")]
        public IActionResult RecuperarUsuarios()
        {

            return Ok("");
        }
    }
}
