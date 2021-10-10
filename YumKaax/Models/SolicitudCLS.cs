using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YumKaax.Models
{
    public class SolicitudCLS
    {
        public int idSolicitud { get; set; }
        public string TituloSolicitud { get; set; }
        public int EstadoSolicitud { get; set; }
        public string DescripcionSolicitud { get; set; }
        public byte[] ImagenSolicitud { get; set; }
        public int idUsuario { get; set; }
        public HttpPostedFileBase Imagen { get; set; }
        public Cat_EstadoSolCLS cat_estadosol { get; set; }
        public UsuariosCLS usuarios { get; set; }
    }
}