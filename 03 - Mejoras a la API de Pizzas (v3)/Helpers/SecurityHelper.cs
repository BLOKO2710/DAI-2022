using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using Pizzas.API.Models;
using Pizzas.API.Utils;
using Pizzas.API.Services;

namespace Pizzas.API.Helpers
{

    public static class SecurityHelper
    {
        // Este método retorna True en el caso de que el token enviado por parámetro 
        // exista en la base de datos y que su ExpirationDate sea válido. 
        public static bool IsValidToken(string token)
        {
            try
            {
                Usuario usuario = UsuariosServices.GetByToken(token);

                bool esValido = false;

                if (usuario != null)
                {
                    int compare = DateTime.Compare(usuario.TokenExpirationDate, DateTime.Now);

                    if (compare > 0)
                    {
                        esValido = true;
                    }
                }
                else
                {
                    esValido = false;
                }

                return esValido;
            }
            catch (System.Exception)
            {

                throw;
            }

        }

    }

}
