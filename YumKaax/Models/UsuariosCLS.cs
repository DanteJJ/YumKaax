using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YumKaax.Models
{
    public class UsuariosCLS
    {
        public int idUsuarios { get; set; }
        public string NickUsuarios { get; set; }
        public string PassUsuarios { get; set; }
        public string CorreoUsuarios { get; set; }
        public int TipoUserUsuarios { get; set; }
        public string BackPassUsuarios { get; set; }
        public string TelefonoUsuarios { get; set; }
        public int EstadoUsuarios { get; set; }
    }
}