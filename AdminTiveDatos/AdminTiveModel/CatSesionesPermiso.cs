using System;
using System.Collections.Generic;

#nullable disable

namespace AdminTiveDatos.AdminTiveModel
{
    public partial class CatSesionesPermiso
    {
        public int PermisoId { get; set; }
        public short? SubModuloId { get; set; }
        public int? PerfilId { get; set; }
        public int? UsuarioId { get; set; }

        public virtual CatSesionesPerfile Perfil { get; set; }
        public virtual CatSesionesSubModulo SubModulo { get; set; }
        public virtual CatSesionesUsuario Usuario { get; set; }
    }
}
