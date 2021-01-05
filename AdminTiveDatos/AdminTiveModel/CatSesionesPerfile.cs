using System;
using System.Collections.Generic;

#nullable disable

namespace AdminTiveDatos.AdminTiveModel
{
    public partial class CatSesionesPerfile
    {
        public CatSesionesPerfile()
        {
            CatSesionesPermisos = new HashSet<CatSesionesPermiso>();
            CatSesionesUsuarios = new HashSet<CatSesionesUsuario>();
        }

        public int PerfilId { get; set; }
        public string Perfil { get; set; }

        public virtual ICollection<CatSesionesPermiso> CatSesionesPermisos { get; set; }
        public virtual ICollection<CatSesionesUsuario> CatSesionesUsuarios { get; set; }
    }
}
