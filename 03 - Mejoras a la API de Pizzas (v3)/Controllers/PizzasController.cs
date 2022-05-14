using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;
using Pizzas.API.Utils;
using Pizzas.API.Services;
using Pizzas.API.Helpers;
using Dapper;
using System.Reflection;

namespace Pizzas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzasController : ControllerBase
    {

        [HttpGet]
        // TERMINADO
        public IActionResult GetAll()
        {
            try
            {
                IActionResult respuesta;
                List<Pizza> entitylist;

                entitylist = PizzasServices.GetAll();
                respuesta = Ok(entitylist);

                return respuesta;
            }
            catch (Exception ex)
            {
                MethodBase m = MethodBase.GetCurrentMethod();
                CustomLog.LogError(ex, m.DeclaringType.Name, m.Name);
                return Problem(
                    detail: ex.Message,
                    title: "Error al obtener las pizzas",
                    statusCode: 500
                );
            }
        }

        [HttpGet("{id}")]
        // TERMINADO 
        public IActionResult GetById(int id)
        {
            IActionResult respuesta = null;
            Pizza entity;

            try
            {
                if (id > 0)
                {
                    entity = PizzasServices.GetById(id);
                    if (entity == null)
                    {
                        respuesta = NotFound();
                    }
                    else
                    {
                        respuesta = Ok(entity);
                    }
                }
                return respuesta;
            }

            catch (Exception ex)
            {

                MethodBase m = MethodBase.GetCurrentMethod();

                CustomLog.LogError(ex, m.DeclaringType.Name, m.Name);

                return Problem(
                    detail: ex.Message,
                    title: "Error al obtener una unica pizza",
                    statusCode: 500
                );

            }

        }

        [HttpPost]
        // TERMINADO
        public IActionResult Create(Pizza pizza)
        {
            string token;
            bool tokenValid = false;
            try
            {
                //Obtengo el token del Header

                if (pizza == null)
                {
                    return BadRequest();
                }

                token = Request.Headers["token"];
                tokenValid = SecurityHelper.IsValidToken(token);

                if (tokenValid == true)
                {
                    int rowsAffected = PizzasServices.Insert(pizza, token);
                    return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
                }
                else
                {
                    return Unauthorized();
                }


            }
            catch (Exception ex)
            {

                MethodBase m = MethodBase.GetCurrentMethod();

                CustomLog.LogError(ex, m.DeclaringType.Name, m.Name);

                return Problem(
                    detail: ex.Message,
                    title: "Error al crear pizza",
                    statusCode: 500
                );

            }

        }

        [HttpPut("{id}")]
        // TERMINADO

        public IActionResult Update(int id, Pizza pizza)
        {
            IActionResult respuesta = null;
            int filasAfctadas = 0;

            try
            {
                if (id != pizza.Id || pizza == null)
                {
                    respuesta = BadRequest();
                }

                Pizza pizzaToUpdate = PizzasServices.GetById(id);

                if (pizzaToUpdate == null)
                {
                    respuesta = NotFound();
                }
                else
                {
                    string token = Request.Headers["token"];
                    bool validToken = SecurityHelper.IsValidToken(token);

                    if (validToken == true)
                    {
                        filasAfctadas = PizzasServices.UpdateById(pizza, token, id);

                        if (filasAfctadas == 0 || filasAfctadas == -1)
                        {
                            respuesta = Unauthorized();
                        }

                        else if (filasAfctadas > 0)
                        {
                            respuesta = Ok(pizza);
                        }
                        else
                        {
                            respuesta = NotFound();
                        }
                    }
                    else
                    {
                        respuesta = Unauthorized();
                    }

                }

                return respuesta;
            }
            catch (Exception ex)
            {
                MethodBase m = MethodBase.GetCurrentMethod();

                CustomLog.LogError(ex, m.DeclaringType.Name, m.Name);

                return Problem(
                    detail: ex.Message,
                    title: "Error al actualizar pizza",
                    statusCode: 500
                );
            }

        }

        [HttpDelete("{id}")]
        // TERMINADO
        public IActionResult DeleteById(int id)
        {

            IActionResult respuesta = null;
            Pizza entity;
            int filasAfctadas = 0;

            try
            {
                entity = PizzasServices.GetById(id);

                if (entity == null)
                {
                    respuesta = NotFound();
                }
                else
                {
                    string token = Request.Headers["token"];
                    bool validToken = SecurityHelper.IsValidToken(token);
                    if (validToken)
                    {
                        filasAfctadas = PizzasServices.DeleteById(id, token);

                        if (filasAfctadas > 0)
                        {
                            respuesta = Ok();
                        }
                        else
                        {
                            respuesta = NotFound();
                        }
                    }
                    else
                    {
                        respuesta = Unauthorized();
                    }
                }
                return respuesta;

            }
            catch (Exception ex)
            {

                MethodBase m = MethodBase.GetCurrentMethod();

                CustomLog.LogError(ex, m.DeclaringType.Name, m.Name);

                return Problem(
                    detail: ex.Message,
                    title: "Error al eliminar pizza",
                    statusCode: 500
                );

            }
        }
    }
}
