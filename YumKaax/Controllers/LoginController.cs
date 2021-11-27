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
    public class LoginController : Controller
    {
        public LoginController()
        {
            db = new kukulkanEntities();
        }

        kukulkanEntities db;
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginCLS login)
        {
            if (ModelState.IsValid)
            {
                string passCompare = GetSHA256(login.Pass);
                var user = db.usuarios.Where(m => m.NickUsuarios == login.UserName && m.PassUsuarios == passCompare).FirstOrDefault();
                if (user != null)
                {
                    var tipoUser = (from tu in db.tiposusuario
                                    join u in db.usuarios
                                    on tu.idTiposUsuario equals u.TipoUserUsuarios
                                    where u.idUsuarios == user.idUsuarios
                                    select tu).FirstOrDefault();

                    Session["IdUsuario"] = user.idUsuarios.ToString();
                    Session["NickUsuario"] = user.NickUsuarios.ToString();
                    Session["TipoUser"] = tipoUser.DescTiposUsuario.ToString();
                    Session["IdTipoUser"] = tipoUser.idTiposUsuario.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.credenciales = "Error, revisa tu usuario y/o contraseña";
                    return View();
                }
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
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