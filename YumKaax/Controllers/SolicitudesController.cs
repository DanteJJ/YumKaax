using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YumKaax.Models;

namespace YumKaax.Controllers
{
    public class SolicitudesController : Controller
    {
        // GET: Solicitudes
        public ActionResult CrearSolicitud()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CrearSolicitud(SolicitudCLS solicitud)
        {

            return RedirectToAction("CrearSolicitud");
        }
    }
}