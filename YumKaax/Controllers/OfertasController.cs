using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YumKaax.Models;

namespace YumKaax.Controllers
{
    public class OfertasController : Controller
    {
        public OfertasController()
        {
            db = new kukulkanEntities();

        }
        kukulkanEntities db;
        string idUsuario;
        // GET: Ofertas
        public ActionResult OfertarSolicitud(int idSolicitud)
        {
            SolicitudCLS sol = new SolicitudCLS();
            sol = (from s in db.solicitudes
                  join u in db.usuarios
                  on s.idUsuario equals u.idUsuarios
                  where s.idSolicitud == idSolicitud 
                  select new SolicitudCLS
                  {
                      idSolicitud = s.idSolicitud,
                      TituloSolicitud = s.TituloSolicitud,
                      DescripcionSolicitud = s.DescripcionSolicitud,
                      Usuarios = new UsuariosCLS()
                      {
                          NickUsuarios = u.NickUsuarios,
                      },
                  }).FirstOrDefault();

            List<Images_SolicitudCLS> images_SolicitudCLs = new List<Images_SolicitudCLS>();
            images_SolicitudCLs = (from isC in db.images_solicitud
                                   where isC.idSol_Img_Sol == sol.idSolicitud
                                   select new Images_SolicitudCLS()
                                   {
                                       ImagenImg_Sol = isC.ImagenImg_Sol
                                   }).ToList();
            sol.Images_Solicitud_cl = images_SolicitudCLs;

            List<tipoplanta_solicitud> tps = new List<tipoplanta_solicitud>();
            tps = (from ts in db.tipoplanta_solicitud
                   where ts.IdSolicitud == sol.idSolicitud
                   select ts).ToList();
            List<TipoPlanta_SolicitudCLS> ntp = new List<TipoPlanta_SolicitudCLS>();
            foreach (var itemt in tps)
            {
                TipoPlanta_SolicitudCLS ntp2 = new TipoPlanta_SolicitudCLS();
                                        ntp2 = (from d in db.tipoplantas
                                               where d.idTipoPlantas == itemt.IdtipoPlanta
                                               select new TipoPlanta_SolicitudCLS()
                                               {
                                                   DescTipoPlanta = d.DescripcionTipoPlantas
                                               }).FirstOrDefault();
                ntp.Add(ntp2);
            }
            sol.DescTipoPlanta = ntp;
            
            return View(sol);
        }

        [HttpPost]
        public void OfertarSolicitud(SolicitudCLS solicitudCLS, HttpPostedFileBase[] file)
        {
            idUsuario = Session["IdUsuario"].ToString();
            int idUser = Int32.Parse(idUsuario);
            solicitud_cotizacion so_co = new solicitud_cotizacion();
            so_co.Comentarios_cotizacion = solicitudCLS.Cotizacion_Solicitud.Comentarios_cotizacion;
            so_co.Costo_Cotizacion = solicitudCLS.Cotizacion_Solicitud.Costo_Cotizacion;
            so_co.IdSolicitud = solicitudCLS.idSolicitud;
            so_co.IdUsuarioCotiza = idUser;
            db.solicitud_cotizacion.Add(so_co);
            db.SaveChanges();
        }
    }
}