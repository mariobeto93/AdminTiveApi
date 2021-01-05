using System;
using System.Collections.Generic;
using System.Text;

namespace AdminTiveDatos.AdminTiveEntities.Sesion
{
    public class Permisos
    {
        public int ModuloID { get; set; }
        public string Modulo { get; set; }

        public List<Submodulos> SubModulos { get; set; }
    }

    public class Submodulos
    {
        public int SubModuloID { get; set; }
        public string SubModulo { get; set; }
        public string Url { get; set; }
    }

    public class Usuario
    {
        public string usuarioID { get; set; }
    }
}
