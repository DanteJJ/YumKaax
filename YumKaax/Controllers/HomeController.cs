using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YumKaax.Models;
using PagedList;

namespace YumKaax.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            db = new kukulkanEntities();
        }
        kukulkanEntities db;
        public ActionResult Index(int? page)
        {
            List<SolicitudCLS> sl = new List<SolicitudCLS>();
            sl = (from s in db.solicitudes
                  join u in db.usuarios
                  on s.idUsuario equals u.idUsuarios
                  select new SolicitudCLS { 
                      idSolicitud = s.idSolicitud,
                      TituloSolicitud = s.TituloSolicitud,
                      DescripcionSolicitud = s.DescripcionSolicitud,
                      Usuarios = new UsuariosCLS()
                      {
                          NickUsuarios = u.NickUsuarios,
                      },
                  }).ToList();
            foreach (var item in sl)
            {
                List<Images_SolicitudCLS> images_SolicitudCLs = new List<Images_SolicitudCLS> ();
                images_SolicitudCLs = (from isC in db.images_solicitud
                                       where isC.idSol_Img_Sol == item.idSolicitud
                                       select new Images_SolicitudCLS()
                                       {
                                           ImagenImg_Sol = isC.ImagenImg_Sol
                                       }).ToList();
                item.Images_Solicitud_cl = images_SolicitudCLs;
            }
            return View(sl);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}