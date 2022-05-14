using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;
using Pizzas.API.Utils;
using Pizzas.API.Services;
using System.Reflection;

namespace Pizzas.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public IActionResult Login(Usuario usuario )
        {
            try
            {
                Usuario user = UsuariosServices.Login(usuario.UserName, usuario.Password);
            

            if (user == null)
            {
                return NotFound();
                
            }
            else
            {
                return Ok(user);
                
            }
            }
            catch (Exception ex)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                CustomLog.LogError(ex, m.DeclaringType.Name, m.Name);
                return Problem(
                    detail: ex.Message,
                    title: "Error al obtener el usuario",
                    statusCode: 500
                );
            }
        }
            
    }
}