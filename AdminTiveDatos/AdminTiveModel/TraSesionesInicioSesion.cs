using System;
using System.Collections.Generic;

#nullable disable

namespace AdminTiveDatos.AdminTiveModel
{
    public partial class TraSesionesInicioSesion
    {
        public decimal SesionId { get; set; }
        public int? UsuarioId { get; set; }
        public DateTime? FechaHora { get; set; }

        public virtual CatSesionesUsuario Usuario { get; set; }
    }
}
