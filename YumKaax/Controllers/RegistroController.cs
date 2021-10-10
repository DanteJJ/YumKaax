using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YumKaax.Models;

namespace YumKaax.Controllers
{
    public class RegistroController : Controller
    {
        public RegistroController()
        {
            db = new kukulkanEntities();
        }
        
        public kukulkanEntities db;
        List<tiposusuario> GetTiposusuariosList()
        {
            List<tiposusuario> tiposusuarios = new List<tiposusuario>();
            tiposusuarios = (from tu in db.tiposusuario
                             select tu).ToList();
            return tiposusuarios;
        }

        List<estadouser> GetEstadousersList()
        {
            List<estadouser> estadousers = new List<estadouser>();
            estadousers = (from eu in db.estadouser
                           select eu).ToList();
            return estadousers;
        } 

        // GET: Registro
        public ActionResult Registro()
        {
            ViewBag.ListTipo = new SelectList(GetTiposusuariosList(), "idTiposUsuario", "DescTiposUsuario");
            ViewBag.EdoUser = new SelectList(GetEstadousersList(), "idEstadoUser", "NomEstadoUser");
            return View();
        }
        [HttpPost]
        public ActionResult ConfirmarRegistro(UsuariosCLS Rusuarios)
        {
            usuarios usuarioAg = new usuarios();
            usuarioAg.NickUsuarios = Rusuarios.NickUsuarios;
            usuarioAg.PassUsuarios = Rusuarios.PassUsuarios;
            usuarioAg.CorreoUsuarios = Rusuarios.CorreoUsuarios;
            usuarioAg.EstadoUsuarios = Rusuarios.EstadoUsuarios;
            usuarioAg.TelefonoUsuarios = Rusuarios.TelefonoUsuarios;
            usuarioAg.TipoUserUsuarios = Rusuarios.TipoUserUsuarios;
            db.usuarios.Add(usuarioAg);
            db.SaveChanges();
            return PartialView("Login");
        }
    }
}