using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YumKaax.Models;

namespace YumKaax.Controllers
{
    public class SolicitudesController : Controller
    {
        public SolicitudesController()
        {
            db = new kukulkanEntities();
        }
        kukulkanEntities db;

        List<tipoplantas> GetTipoplantas()
        {
            List<tipoplantas> tp = new List<tipoplantas>();
            tp = (from t in db.tipoplantas
                  select t).ToList();
            return tp;
        }
        // GET: Solicitudes
        public ActionResult CrearSolicitud()
        {
            ViewBag.TiposPlantas = new SelectList(GetTipoplantas(), "idTipoPlantas", "DescripcionTipoPlantas");
            return View();
        }
        [HttpPost]
        public ActionResult CrearSolicitud(string titulo, string descripcion, int[] tiposPlantas, HttpPostedFileBase[] file)
        {
            string us = Session["IdUsuario"].ToString();
            int usu = Int32.Parse(us);
            solicitudes sol = new solicitudes();
            sol.TituloSolicitud = titulo;
            sol.EstadoSolicitud = 1;
            sol.DescripcionSolicitud = descripcion;
            sol.idUsuario = usu;
            db.solicitudes.Add(sol);
            db.SaveChanges();
            solicitudes s = new solicitudes();
            s = (from so in db.solicitudes
                 select so).OrderByDescending(m => m.idSolicitud).FirstOrDefault();
            if (tiposPlantas != null)
            {
                foreach (var item in tiposPlantas)
                {
                    tipoplanta_solicitud tps = new tipoplanta_solicitud();
                    tps.IdtipoPlanta = item;
                    tps.IdSolicitud = s.idSolicitud;
                    db.tipoplanta_solicitud.Add(tps);
                    db.SaveChanges();
                }
            }
            foreach (var item in file)
            {
                if (item != null)
                {
                    images_solicitud images = new images_solicitud();
                    images.idSol_Img_Sol = s.idSolicitud;
                    images.ImagenImg_Sol = convertirImagen(item);
                    db.images_solicitud.Add(images);
                    db.SaveChanges();
                }    
            }
            return RedirectToAction("CrearSolicitud");
        }

        public byte[] convertirImagen (HttpPostedFileBase imagen)
        {
            byte[] imagesBytes = null;
            BinaryReader reader = new BinaryReader(imagen.InputStream);
            imagesBytes = reader.ReadBytes((int)imagen.ContentLength);
            return imagesBytes;
        }
    }
}