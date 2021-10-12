using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YumKaax.Models
{
    public class UsuariosCLS
    {
        public int idUsuarios { get; set; }
        public string NickUsuarios { get; set; }
        public string PassUsuarios { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string CorreoUsuarios { get; set; }
        public int TipoUserUsuarios { get; set; }
        public string BackPassUsuarios { get; set; }
        public string TelefonoUsuarios { get; set; }
        public int EstadoUsuarios { get; set; }
    }
}