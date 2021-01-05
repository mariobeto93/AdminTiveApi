using System;
using System.Collections.Generic;

#nullable disable

namespace AdminTiveDatos.AdminTiveModel
{
    public partial class CatSesionesModulo
    {
        public CatSesionesModulo()
        {
            CatSesionesSubModulos = new HashSet<CatSesionesSubModulo>();
        }

        public short ModuloId { get; set; }
        public string Modulo { get; set; }

        public virtual ICollection<CatSesionesSubModulo> CatSesionesSubModulos { get; set; }
    }
}
