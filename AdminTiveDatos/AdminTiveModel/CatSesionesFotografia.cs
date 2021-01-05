using System;
using System.Collections.Generic;

#nullable disable

namespace AdminTiveDatos.AdminTiveModel
{
    public partial class CatSesionesFotografia
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public byte[] Foto { get; set; }

        public virtual CatSesionesUsuario Usuario { get; set; }
    }
}
