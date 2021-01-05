using System;
using System.Collections.Generic;

#nullable disable

namespace AdminTiveDatos.AdminTiveModel
{
    public partial class CatSesionesSubModulo
    {
        public CatSesionesSubModulo()
        {
            CatSesionesPermisos = new HashSet<CatSesionesPermiso>();
        }

        public short SubModuloId { get; set; }
        public short? ModuloId { get; set; }
        public string SubModulo { get; set; }
        public string Url { get; set; }
        public string Modelo { get; set; }
        public string Controlador { get; set; }

        public virtual CatSesionesModulo Modulo { get; set; }
        public virtual ICollection<CatSesionesPermiso> CatSesionesPermisos { get; set; }
    }
}
