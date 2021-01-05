using System;
using System.Collections.Generic;
using System.Text;
using AdminTiveDatos.AdminTiveEntities.Respuestas;

namespace AdminTiveLogica.Administracion
{
    class AdministracionLogica
    {
        public static RespuestaConsulta RecuperarUsuarios()
        {
            try
            {
                return new RespuestaConsulta();
            }
            catch (Exception ex)
            {
                return new RespuestaConsulta();
            }
        }
    }
}
