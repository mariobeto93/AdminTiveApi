using System;
using System.Collections.Generic;
using System.Text;

namespace AdminTiveDatos.AdminTiveEntities.Sesion
{
    public class Sesion
    {
        public Int64 UsuarioID { get; set; }
        public string User { get; set; }
        public string UserName { get; set; }
        public byte[] Foto { get; set; }
    }
}
