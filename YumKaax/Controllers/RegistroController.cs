using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            usuarioAg.PassUsuarios = GetSHA256(Rusuarios.PassUsuarios);
            usuarioAg.CorreoUsuarios = Rusuarios.CorreoUsuarios;
            usuarioAg.EstadoUsuarios = Rusuarios.EstadoUsuarios;
            usuarioAg.TelefonoUsuarios = Rusuarios.TelefonoUsuarios;
            usuarioAg.TipoUserUsuarios = Rusuarios.TipoUserUsuarios;
            db.usuarios.Add(usuarioAg);
            db.SaveChanges();
            return PartialView("Login");
        }
        public sbyte CheckNick(string nick)
        {
            sbyte aux = 0;
            int user = (from u in db.usuarios
                    where u.NickUsuarios == nick
                    select u).Count();
            if (user != 0)
            {
                aux = 1;
            }
            return aux;
        }
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

    }
}