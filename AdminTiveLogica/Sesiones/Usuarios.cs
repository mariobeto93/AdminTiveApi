using System;
using System.Collections.Generic;
using System.Text;
using AdminTiveDatos.AdminTiveModel;
using AdminTiveDatos.AdminTiveEntities.Sesion;
using System.Linq;
using AdminTiveDatos.AdminTiveEntities.Respuestas;
using Newtonsoft.Json;

namespace AdminTiveLogica.Sesiones
{
    public class Usuarios
    {
        public static Sesion RecuperarUsuario(int usuarioID)
        {
            using (AdminTiveWebContext db = new AdminTiveWebContext())
            {
                var usuario = (from u in db.CatSesionesUsuarios
                               join f in db.CatSesionesFotografias on u.UsuarioId equals f.UsuarioId into Fotos
                               from ft in Fotos.DefaultIfEmpty()
                               where u.UsuarioId == usuarioID
                               select new Sesion
                               {
                                   UsuarioID = u.UsuarioId,
                                   User = u.Email,
                                   UserName = u.Nombres,
                                   Foto = ft == null ? new byte[0] : ft.Foto
                               }
                               ).FirstOrDefault();

                return usuario;
            }
        }

        public static RespuestaConsulta Autentificar(Credenciales credenciales)
        {
            using (AdminTiveWebContext db = new AdminTiveWebContext())
            {
                var usuario = (from u in db.CatSesionesUsuarios
                               where u.Email == credenciales.email
                                && u.Password == credenciales.pass
                               select u).Count();

                RespuestaConsulta respuesta = new RespuestaConsulta();

                if(usuario > 0)
                {
                    respuesta.success = true;
                    respuesta.mensaje = "2";
                }
                else
                {
                    respuesta.success = false;
                    respuesta.mensaje = "Usuario o contraseña incorrecta";
                }

                return respuesta;
            }
        }

        public static RespuestaConsulta RecuperarPermisos(int usuarioID)
        {
            using (AdminTiveWebContext db = new AdminTiveWebContext())
            {
                var permisos = (from p in db.CatSesionesPermisos
                                join sm in db.CatSesionesSubModulos on p.SubModuloId equals sm.SubModuloId
                                join m in db.CatSesionesModulos on sm.ModuloId equals m.ModuloId
                               where p.UsuarioId == usuarioID
                               select new { 
                                    ModuloID = m.ModuloId,
                                    Modulo = m.Modulo,
                                    SubModuloID = sm.SubModuloId,
                                    SubModulo = sm.SubModulo,
                                    Url = sm.Url
                               }).ToList();

                var Modulos = (from p in permisos
                               select new Permisos(){ 
                                    ModuloID = p.ModuloID,
                                    Modulo = p.Modulo
                               }).Distinct().ToList();

                foreach (Permisos mod in Modulos)
                {
                    mod.SubModulos = permisos.Where(x => x.ModuloID == mod.ModuloID).Select(x => new Submodulos
                    {
                        SubModuloID = x.SubModuloID,
                        SubModulo = x.SubModulo,
                        Url = x.Url
                    }).ToList();
                }

                RespuestaConsulta respuesta = new RespuestaConsulta();

                if (Modulos.Count > 0)
                {
                    respuesta.success = true;
                    respuesta.mensaje = JsonConvert.SerializeObject(Modulos);
                }
                else
                {
                    respuesta.success = false;
                    respuesta.mensaje = "";
                }

                return respuesta;
            }
        }

        public static bool ActualizarSesion(string email)
        {
            try
            {
                bool status = true;

                using (AdminTiveWebContext db = new AdminTiveWebContext())
                {
                    var usuarioID = (from u in db.CatSesionesUsuarios
                                     where u.Email == email
                                     select u.UsuarioId).FirstOrDefault();

                    if (usuarioID != null)
                    {
                        var sesion = (from s in db.TraSesionesInicioSesions
                                      where s.UsuarioId == usuarioID
                                      select s).FirstOrDefault();

                        if (sesion == null)
                        {
                            TraSesionesInicioSesion ses = new TraSesionesInicioSesion();
                            ses.UsuarioId = usuarioID;
                            ses.FechaHora = DateTime.Now;
                            db.TraSesionesInicioSesions.Add(ses);
                            db.SaveChanges();
                        }
                        else if (DiferenciaMinutos(sesion.FechaHora, null) > 5)
                        {
                            status = false;
                        }
                        else
                        {
                            sesion.FechaHora = DateTime.Now;
                            db.SaveChanges();
                        }
                    }
                    
                }

                    return status;
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static double DiferenciaMinutos(DateTime? FechaInicio, DateTime? FechaFin)
        {
            try
            {
                TimeSpan diferencia = (FechaFin ?? DateTime.Now) - (FechaInicio ?? DateTime.Now);
                return diferencia.TotalMinutes;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static RespuestaConsulta isLoggedIn(string email)
        {
            RespuestaConsulta respuesta = new RespuestaConsulta();

            if (email != null && email != "" && ActualizarSesion(email))
            {
                respuesta.success = true;
                respuesta.mensaje = "Sesion Activa";
            }
            else
            {
                respuesta.success = false;
                respuesta.mensaje = "Sesion Inactiva";
            }

            return respuesta;
            
        }
    }
}
