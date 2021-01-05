using System;
using System.Collections.Generic;

#nullable disable

namespace AdminTiveDatos.AdminTiveModel
{
    public partial class CatSesionesUsuario
    {
        public CatSesionesUsuario()
        {
            CatSesionesFotografia = new HashSet<CatSesionesFotografia>();
            CatSesionesPermisos = new HashSet<CatSesionesPermiso>();
            TraSesionesInicioSesions = new HashSet<TraSesionesInicioSesion>();
        }

        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public string Nombres { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Password { get; set; }
        public int? PerfilId { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? UltimoEvento { get; set; }
        public int? SecionActiva { get; set; }
        public int Genero { get; set; }

        public virtual CatSesionesPerfile Perfil { get; set; }
        public virtual ICollection<CatSesionesFotografia> CatSesionesFotografia { get; set; }
        public virtual ICollection<CatSesionesPermiso> CatSesionesPermisos { get; set; }
        public virtual ICollection<TraSesionesInicioSesion> TraSesionesInicioSesions { get; set; }
    }
}
